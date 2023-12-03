using UnityEngine;

public abstract class Bullet : ObjectPoolClient, IBullet
{
    private Vector2 _direction;
    private Vector2 _startPosition;
    [SerializeField] private float _speed = 5f;
    [SerializeField] private float _maxDistance = 10f;

    public void Initialize(Vector2 position, Vector2 newDirection)
    {
        if (gameObject.activeSelf)
            return;

        _direction = newDirection.normalized;
        _startPosition = position;
        transform.position = position;
        RotateToDirection();
        OnInitialize();
        gameObject.SetActive(true);
    }

    protected virtual void OnInitialize() { }

    protected abstract Vector2 Movement(Vector2 direction, float speed);

    private void Update()
    {
        Vector2 movement = Movement(_direction, _speed);
        transform.position += (Vector3)movement;

        float curentDistance = Vector2.Distance(_startPosition, transform.position);
        if (curentDistance > _maxDistance)
            ReturnToPool();
    }

    private void RotateToDirection()
    {
        float angle = Mathf.Atan2(_direction.y, _direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, angle);
    }
}