using UnityEngine;

public class Spawner<T> where T : MonoBehaviour
{
    private Counter _counter;
    private int _spawnedCount = 0;

    public Spawner(Counter counter)
    {
        _counter = counter;
    }

    public void Spawn(Vector3 spawnPoint, T gameObject)
    {        
        gameObject.gameObject.SetActive(true);

        gameObject.transform.position = spawnPoint;

        _counter.ShowInfo(_spawnedCount++);
    }
}
