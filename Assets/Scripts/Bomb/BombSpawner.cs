using UnityEngine;

public class BombSpawner : MonoBehaviour
{
    [SerializeField] private BombPool _pool;
    [SerializeField] private View _view;

    private Spawner<Bomb> _spawner;

    private void Awake()
    {
        _spawner = new Spawner<Bomb>(_view);
    }

    public void Spawn(Vector3 spawnpoint)
    {
        _spawner.Spawn(spawnpoint, _pool.GetBomb());
    }
}
