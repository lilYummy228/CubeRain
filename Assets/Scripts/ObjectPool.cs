using System.Collections.Generic;
using UnityEngine;

public class ObjectPool<T> where T : MonoBehaviour
{
    private T _prefab;
    private Transform _container;
    private Queue<T> _pool = new();

    public ObjectPool(T prefab, Transform container)
    {
        _prefab = prefab;
        _container = container;
    }

    public T GetObject()
    {
        if (_pool.Count == 0)
        {
            T gameObject = Object.Instantiate(_prefab);
            gameObject.transform.parent = _container;                              

            return gameObject;
        }

        return _pool.Dequeue();
    }

    public void PutObject(T gameObject)
    {
        _pool.Enqueue(gameObject);
        gameObject.gameObject.SetActive(false);
    }
}