using UnityEngine;

public class StandardBullet : Bullet
{
    protected override Vector2 Movement(Vector2 direction, float speed)
    {
        return speed * Time.deltaTime * direction;
    }
}
