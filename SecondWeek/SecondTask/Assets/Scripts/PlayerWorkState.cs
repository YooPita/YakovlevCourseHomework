using UnityEngine;

public class PlayerWorkState : IState
{
    private readonly IPointWalker _pointWalker;
    private readonly Vector2 _point;
    private readonly Waiter _waiter = new();
    private readonly IPlayerStates _states;
    private bool _work = false;

    public PlayerWorkState(IPointWalker pointWalker, Vector2 point, IPlayerStates states)
    {
        _pointWalker = pointWalker;
        _point = point;
        _states = states;
    }

    public void Start()
    {
        _work = false;
        _pointWalker.MoveToPoint(_point);
        Debug.Log($"go to work");
    }

    public IState Execute()
    {
        if (!_work)
        {
            if (_pointWalker.IsAtPoint())
            {
                _work = true;
                float seconds = 2f;
                _waiter.Wait(seconds);
                Debug.Log($"work {seconds} seconds");
            }
        }
        else
        {
            if (_waiter.Check())
                return _states.Sleep();
        }
        return this;
    }
}