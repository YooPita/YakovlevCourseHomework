using System.Collections.Generic;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class Player : MonoBehaviour, IPointWalker, IPlayerStates
{
    [SerializeField] private float _speed = 5f;
    [SerializeField] private Vector2 _sleepPosition;
    [SerializeField] private Vector2 _workPosition;
    [SerializeField] private List<Vector2> _relaxPositions = new();
    [SerializeField] private TextMeshPro _text;
    private Animator _animator;
    private bool _isAtPoint = true;
    private Vector2 _currentPoint;
    private IState _currentState;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        Stand();
        _currentState = Relax();
        _currentState.Start();
    }

    private void Update()
    {
        Move();
        IState newState = _currentState.Execute();
        if (newState != _currentState)
            newState.Start();
        _currentState = newState;
    }

    public IState Work()
    {
        UpdateStateText("Work");
        return new PlayerWorkState(this, _workPosition, this);
    }

    public IState Sleep()
    {
        UpdateStateText("Sleep");
        return new PlayerSleepState(this, _sleepPosition, this);
    }

    public IState Relax()
    {
        UpdateStateText("Chill");
        return new PlayerRelaxState(this, _relaxPositions, this);
    }

    public void MoveToPoint(Vector2 point)
    {
        _currentPoint = point;
        _isAtPoint = false;
        Walk();
    }

    public bool IsAtPoint() => _isAtPoint;

    private void Stand() => _animator.SetBool("Walk", false);

    private void Walk() => _animator.SetBool("Walk", true);

    private void Move()
    {
        if (_isAtPoint)
            return;

        float step = _speed * Time.deltaTime;
        transform.position = Vector2.MoveTowards(transform.position, _currentPoint, step);
        if (Vector2.Distance(transform.position, _currentPoint) < 0.001f)
        {
            _isAtPoint = true;
            Stand();
        }
    }

    private void UpdateStateText(string text)
    {
        _text.text = text;
    }
}
