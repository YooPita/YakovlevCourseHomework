using UnityEngine;
using UnityEngine.InputSystem;

public class IdlingState : GroundedState
{
    public IdlingState(IStateSwitcher stateSwitcher, StateMachineData data, Character character) : base(stateSwitcher, data, character)
    {
    }

    public override void Enter()
    {
        base.Enter();

        View.StartIdling();
    }

    public override void Exit()
    {
        base.Exit();

        View.StopIdling();
    }

    public override void Update()
    {
        base.Update();
        if (IsHorizontalInputZero())
            return;

        StateSwitcher.SwitchState<WalkingState>();
    }

    protected override void OnFalling() => StateSwitcher.SwitchState<SlowFallingState>();

    protected override void OnJumpKeyPressed(InputAction.CallbackContext obj) => StateSwitcher.SwitchState<SlowJumpingState>();
}
