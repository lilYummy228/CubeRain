using System.Collections.Generic;
using UnityEngine;

public class CubePool : MonoBehaviour
{
    [SerializeField] private Cube _cube;
    [SerializeField] private Transform _container;

    private Queue<Cube> _pool = new();

    public Cube GetCube()
    {
        if (_pool.Count == 0)
        {
            Cube cube = Instantiate(_cube);
            cube.transform.parent = _container;

            return cube;
        }

        return _pool.Dequeue();
    }

    public void PutCube(Cube cube)
    {
        _pool.Enqueue(cube);
        cube.gameObject.SetActive(false); 
    }
}
