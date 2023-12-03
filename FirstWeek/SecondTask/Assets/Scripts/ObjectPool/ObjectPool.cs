using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour, IObjectPool, IObjectPoolServer
{
    [SerializeField] private GameObject objectPrefab;

    private Queue<GameObject> objects = new Queue<GameObject>();

    public GameObject Instance()
    {
        if (objects.Count == 0)
            AddObject();
        return objects.Dequeue();
    }

    public void ReturnToPool(GameObject objectToReturn)
    {
        objectToReturn.SetActive(false);
        objects.Enqueue(objectToReturn);
    }

    private void AddObject()
    {
        var newObject = Instantiate(objectPrefab, transform);
        newObject.GetComponent<IObjectPoolClient>().Connect(this);
        newObject.SetActive(false);
        objects.Enqueue(newObject);
    }
}