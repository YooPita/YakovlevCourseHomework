public class FastJumpingState : AirborneState
{
    private readonly AirborneStateConfig _config;

    public FastJumpingState(IStateSwitcher stateSwitcher, StateMachineData data, Character character) : base(stateSwitcher, data, character)
        => _config = character.Config.FastAirborneStateConfig;

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
            StateSwitcher.SwitchState<FastFallingState>();
    }

    protected override float GetGravityMultipliyer() => _config.BaseGravity;
}
