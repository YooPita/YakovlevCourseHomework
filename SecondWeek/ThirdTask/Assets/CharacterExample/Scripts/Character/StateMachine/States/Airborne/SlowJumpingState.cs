public class SlowJumpingState : AirborneState
{
    private readonly AirborneStateConfig _config;

    public SlowJumpingState(IStateSwitcher stateSwitcher, StateMachineData data, Character character) : base(stateSwitcher, data, character)
        => _config = character.Config.SlowAirborneStateConfig;

    public override void Enter()
    {
        base.Enter();

        View.StartJumping();

        Data.Speed = _config.Speed;
        Data.YVelocity = _config.JumpingStateConfig.StartYVelocity;
    }

    public override void Exit()
    {
        base.Exit();

        View.StopJumping();
    }

    public override void Update()
    {
        base.Update();

        if (Data.YVelocity <= 0)
            StateSwitcher.SwitchState<SlowFallingState>();
    }

    protected override float GetGravityMultipliyer() => _config.BaseGravity;
}
