using UnityEngine;

public interface IPointWalker
{
    void MoveToPoint(Vector2 point);

    bool IsAtPoint();
}