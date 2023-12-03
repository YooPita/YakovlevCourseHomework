using UnityEngine;

public interface IObjectPoolServer
{
    void ReturnToPool(GameObject objectToReturn);
}