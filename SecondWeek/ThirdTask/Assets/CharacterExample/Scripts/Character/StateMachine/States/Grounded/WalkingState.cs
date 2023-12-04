using UnityEngine.InputSystem;

public class WalkingState : GroundedState
{
    private readonly WalkingStateConfig _config;

    public WalkingState(IStateSwitcher stateSwitcher, StateMachineData data, Character character) : base(stateSwitcher, data, character)
        => _config = character.Config.WalkingStateConfig;

    public override void Enter()
    {
        base.Enter();

        View.StartRunning();
        Data.Speed = _config.Speed;
    }

    public override void Exit()
    {
        base.Exit();

        View.StopRunning();
    }

    public override void Update()
    {
        base.Update();

        if (IsHorizontalInputZero())
            StateSwitcher.SwitchState<IdlingState>();

        if (IsRunning())
            StateSwitcher.SwitchState<RunningState>();
    }

    protected override void OnFalling() => StateSwitcher.SwitchState<SlowFallingState>();

    protected override void OnJumpKeyPressed(InputAction.CallbackContext obj) => StateSwitcher.SwitchState<SlowJumpingState>();
}
