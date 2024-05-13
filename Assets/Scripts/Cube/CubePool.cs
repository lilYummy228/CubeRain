using UnityEngine;

public class CubePool : MonoBehaviour
{
    [SerializeField] private Cube _cube;
    [SerializeField] private Transform _container;
    [SerializeField] private BombSpawner _bombSpawner;
    [SerializeField] private Counter _counter;

    private ObjectPool<Cube> _cubePool;

    private void Awake()
    {
        _cubePool = new ObjectPool<Cube>(_cube, _container);
    }

    public Cube GetObject()
    {
        Cube cube = _cubePool.GetObject();
        cube.Landed += PutObject;

        return cube;
    }

    public void PutObject(Cube cube)
    {
        _cubePool.PutObject(cube);
        cube.Landed -= PutObject;

        _bombSpawner.Spawn(cube.transform.position);
    }
}
