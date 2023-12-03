using UnityEngine;

public abstract class Gun : IGun
{
    protected float _shootInterval = 0f;

    private Transform _initialPoint;
    private IBulletPool _bulletPool;
    private float _lastShootTime = 0f;

    public Gun(IBulletPool bulletPool, Transform initialPoint)
    {
        _bulletPool = bulletPool;
        _initialPoint = initialPoint;
    }

    public abstract int Ammo();

    public void Shoot()
    {
        if(CheckShootInterval() == false)
            return;
        _lastShootTime = Time.time;
        OnShoot();
    }

    protected virtual void OnShoot() { }

    protected IBullet Bullet() => _bulletPool.Instance();

    protected Vector2 InitialPosition() => _initialPoint.position;

    protected Vector2 InitialRotation() => _initialPoint.right;

    protected bool CheckShootInterval() => (Time.time - _lastShootTime > _shootInterval);
}