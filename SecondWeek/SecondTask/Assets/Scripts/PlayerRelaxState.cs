using System.Collections.Generic;
using UnityEngine;

public class PlayerRelaxState : IState
{
    private readonly IPointWalker _pointWalker;
    private readonly Waiter _waiter = new();
    private readonly IPlayerStates _states;
    private readonly List<Vector2> _points;
    private System.Random _random = new();

    public PlayerRelaxState(IPointWalker pointWalker, List<Vector2> points, IPlayerStates states)
    {
        _pointWalker = pointWalker;
        _points = points;
        _states = states;
    }

    public void Start()
    {
        float seconds = _random.Next(3, 11);
        _waiter.Wait(seconds);
        Vector2 point = GetRandomPoint();
        _pointWalker.MoveToPoint(point);
        Debug.Log($"chill for {seconds} seconds");
    }

    public IState Execute()
    {
        SetRandomDirection();
        if (_waiter.Check())
            return _states.Work();
        return this;
    }

    private void SetRandomDirection()
    {
        if (_pointWalker.IsAtPoint())
            _pointWalker.MoveToPoint(GetRandomPoint());
    }

    private Vector2 GetRandomPoint()
    {
        int index = _random.Next(_points.Count);
        return _points[index];
    }
}