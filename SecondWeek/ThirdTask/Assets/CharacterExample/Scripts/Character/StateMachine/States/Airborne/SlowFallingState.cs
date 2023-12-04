using Unity.VisualScripting.FullSerializer;

public class SlowFallingState : AirborneState
{
    private readonly GroundChecker _groundChecker;
    private readonly AirborneStateConfig _config;

    public SlowFallingState(IStateSwitcher stateSwitcher, StateMachineData data, Character character) : base(stateSwitcher, data, character)
    {
        _groundChecker = character.GroundChecker;
        _config = character.Config.SlowAirborneStateConfig;
    }


    public override void Enter()
    {
        base.Enter();

        Data.Speed = _config.Speed;
        View.StartFalling();
    }

    public override void Exit()
    {
        base.Exit();

        View.StopFalling();
    }

    public override void Update()
    {
        base.Update();

        if (_groundChecker.IsTouches)
        {
            Data.YVelocity = 0;

            if (IsHorizontalInputZero())
                StateSwitcher.SwitchState<IdlingState>();
            else if (IsRunning())
                StateSwitcher.SwitchState<RunningState>();
            else
                StateSwitcher.SwitchState<WalkingState>();
        }
    }

    protected override float GetGravityMultipliyer() => _config.BaseGravity;
}
