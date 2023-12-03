using UnityEngine;

// Шаблонный метод
public abstract class ObjectPoolClient : MonoBehaviour, IObjectPoolClient
{
    private IObjectPoolServer _pool;

    public void Connect(IObjectPoolServer objectPool) => _pool = objectPool;

    protected void ReturnToPool() => _pool.ReturnToPool(gameObject);
}