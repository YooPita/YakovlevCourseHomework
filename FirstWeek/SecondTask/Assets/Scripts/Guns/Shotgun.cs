using UnityEngine;

public class Shotgun : Gun
{
    private const int OneShot = 3;

    private float _maxDeviationAngle;
    private int _ammo;

    public Shotgun(IBulletPool bulletPool, Transform initialPoint, int ammo, float maxDeviationAngle = 5f) : base(bulletPool, initialPoint)
    {
        _ammo = ammo < 0 ? 0 : NormalizeAmmo(ammo);
        _maxDeviationAngle = maxDeviationAngle;
        _shootInterval = 0.5f;
    }

    public override int Ammo() => _ammo;

    protected override void OnShoot()
    {
        if (_ammo == 0)
            return;

        _ammo = _ammo - OneShot <= 0 ? 0 : _ammo - OneShot;

        Vector2 initialRotation = InitialRotation();
        Vector2 newDirectionLeft = RotateDirection(initialRotation, -_maxDeviationAngle);
        Vector2 newDirectionRight = RotateDirection(initialRotation, _maxDeviationAngle);

        Bullet().Initialize(InitialPosition(), initialRotation);
        Bullet().Initialize(InitialPosition(), newDirectionLeft);
        Bullet().Initialize(InitialPosition(), newDirectionRight);
    }

    private Vector2 RotateDirection(Vector2 direction, float angle)
    {
        float baseAngle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        float newAngle = baseAngle + angle;
        return AngleToVector2(newAngle);
    }

    private Vector2 AngleToVector2(float angleInDegrees)
    {
        float radians = angleInDegrees * Mathf.Deg2Rad;
        return new Vector2(Mathf.Cos(radians), Mathf.Sin(radians));
    }

    private int NormalizeAmmo(int ammo)
    {
        if (ammo % OneShot == 0)
            return ammo;
        else
            return ammo - (ammo % OneShot);
    }
}