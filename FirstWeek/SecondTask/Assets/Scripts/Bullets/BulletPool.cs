public class BulletPool : ObjectPool, IBulletPool
{
    public new IBullet Instance()
    {
        return base.Instance().GetComponent<Bullet>();
    }
}