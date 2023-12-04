using UnityEngine;

public abstract class AirborneState : MovementState
{
    public AirborneState(IStateSwitcher stateSwitcher, StateMachineData data, Character character) : base(stateSwitcher, data, character) { }

    public override void Enter()
    {
        base.Enter();

        View.StartAirborne();
    }

    public override void Exit()
    {
        base.Exit();

        View.StopAirborne();
    }

    public override void Update()
    {
        base.Update();

        Data.YVelocity -= GetGravityMultipliyer() * Time.deltaTime;
    }

    protected abstract float GetGravityMultipliyer();
}
