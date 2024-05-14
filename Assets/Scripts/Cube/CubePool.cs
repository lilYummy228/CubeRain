using System;
using UnityEngine;

public class CubePool : MonoBehaviour
{
    private const int Unit = 1;

    [SerializeField] private Cube _cube;
    [SerializeField] private Transform _container;
    [SerializeField] private BombSpawner _bombSpawner;

    private ObjectPool<Cube> _cubePool;

    public event Action<int> CubeCountChanged;

    private void Awake()
    {
        _cubePool = new ObjectPool<Cube>(_cube, _container);
    }

    public Cube GetObject()
    {
        Cube cube = _cubePool.GetObject();
        cube.Landed += PutObject;

        CubeCountChanged?.Invoke(Unit);

        return cube;
    }

    public void PutObject(Cube cube)
    {
        _cubePool.PutObject(cube);
        cube.Landed -= PutObject;

        CubeCountChanged?.Invoke(-Unit);

        _bombSpawner.Spawn(cube.transform.position);
    }
}
