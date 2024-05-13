using UnityEngine;

public class BombSpawner : MonoBehaviour
{
    [SerializeField] private BombPool _pool;
    [SerializeField] private Counter _counter;

    private Spawner<Bomb> _spawner;

    private void Awake()
    {
        _spawner = new Spawner<Bomb>(_counter);
    }

    public void Spawn(Vector3 spawnpoint)
    {
        _spawner.Spawn(spawnpoint, _pool.GetBomb());
    }
}
