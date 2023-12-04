using UnityEngine;

public class PlayerSleepState : IState
{
    private readonly IPointWalker _pointWalker;
    private readonly Vector2 _point;
    private readonly Waiter _waiter = new();
    private readonly IPlayerStates _states;
    private bool _sleep = false;

    public PlayerSleepState(IPointWalker pointWalker, Vector2 point, IPlayerStates states)
    {
        _pointWalker = pointWalker;
        _point = point;
        _states = states;
    }

    public void Start()
    {
        _sleep = false;
        _pointWalker.MoveToPoint(_point);
        Debug.Log($"go to sleep");
    }

    public IState Execute()
    {
        if (!_sleep)
        {
            if (_pointWalker.IsAtPoint())
            {
                _sleep = true;
                float seconds = 5f;
                _waiter.Wait(seconds);
                Debug.Log($"sleep {seconds} seconds");
            }
        }
        else
        {
            if (_waiter.Check())
                return _states.Relax();
        }

        return this;
    }
}