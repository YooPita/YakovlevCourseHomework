using UnityEngine;

public class RocketGun : Gun
{
    private int _ammo;

    public RocketGun(IBulletPool bulletPool, Transform initialPoint, int ammo) : base(bulletPool, initialPoint)
    {
        _ammo = ammo < 0 ? 0 : ammo;
        _shootInterval = 0.7f;
    }

    public override int Ammo() => _ammo;

    protected override void OnShoot()
    {
        if (_ammo == 0)
            return;

        _ammo--;
        IBullet bullet = Bullet();
        bullet.Initialize(InitialPosition(), InitialRotation());
    }
}