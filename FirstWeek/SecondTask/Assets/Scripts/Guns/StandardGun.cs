using UnityEngine;

public class StandardGun : Gun
{
    [SerializeField] private float _maxDeviationAngle;

    public StandardGun(IBulletPool bulletPool, Transform initialPoint, float maxDeviationAngle = 5f) : base(bulletPool, initialPoint)
    {
        _maxDeviationAngle = maxDeviationAngle;
        _shootInterval = 0.3f;
}

    public override int Ammo() => -1;

    protected override void OnShoot()
    {
        Vector2 newDirection = RandomizeDirection(InitialRotation());
        //Vector2 newDirection = InitialRotation();
        IBullet bullet = Bullet();
        bullet.Initialize(InitialPosition(), newDirection);
    }

    private Vector2 RandomizeDirection(Vector2 direction)
    {
        float deviation = Random.Range(-_maxDeviationAngle, _maxDeviationAngle);
        float baseAngle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        float newAngle = baseAngle + deviation;
        return AngleToVector2(newAngle);
    }

    private Vector2 AngleToVector2(float angleInDegrees)
    {
        float radians = angleInDegrees * Mathf.Deg2Rad;
        return new Vector2(Mathf.Cos(radians), Mathf.Sin(radians));
    }
}