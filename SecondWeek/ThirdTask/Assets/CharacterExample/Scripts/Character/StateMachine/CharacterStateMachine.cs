using System.Collections.Generic;
using System.Linq;

public class CharacterStateMachine: IStateSwitcher
{
    private List<IState> _states;
    private IState _currentState;

    public CharacterStateMachine(Character character)
    {
        StateMachineData data = new StateMachineData();

        _states = new List<IState>()
        {
            new IdlingState(this, data, character),
            new WalkingState(this, data, character),
            new RunningState(this, data, character),
            new FastJumpingState(this, data, character),
            new SlowJumpingState(this, data, character),
            new FastFallingState(this, data, character),
            new SlowFallingState(this, data, character),
        };

        _currentState = _states[0];
        _currentState.Enter();
    }

    public void SwitchState<State>() where State : IState
    {
        IState state = _states.FirstOrDefault(state => state is State);

        _currentState.Exit();
        _currentState = state;
        _currentState.Enter();
    }

    public void HandleInput() => _currentState.HandleInput();

    public void Update() => _currentState.Update();
}