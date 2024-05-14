using System.Collections;
using UnityEngine;

public class CubeSpawner : MonoBehaviour
{
    [SerializeField] private Transform _platform;
    [SerializeField] private CubePool _pool;
    [SerializeField] private View _view;

    private Spawner<Cube> _spawner;

    private float _waitTime = 1f;
    private float _muliplier = 5f;
    private float _positionX;
    private float _positionZ;
    private WaitForSeconds _wait;

    private void Start()
    {
        _positionX = _platform.localScale.x * _muliplier;
        _positionZ = _platform.localScale.z * _muliplier;

        _spawner = new Spawner<Cube>(_view);       

        _wait = new WaitForSeconds(_waitTime);

        StartCoroutine(nameof(GenerateCubes));
    }

    private IEnumerator GenerateCubes()
    {
        while (enabled)
        {
            yield return _wait;
            Spawn();
        }
    }

    private void Spawn()
    {
        float spawnPositionX = Random.Range(-_positionX, _positionX);   
        float spawnPositionZ = Random.Range(-_positionZ, _positionZ);
        Vector3 spawnPoint = new Vector3(spawnPositionX, transform.position.y, spawnPositionZ);

        Cube cube = _pool.GetObject();
        _spawner.Spawn(spawnPoint, cube);
        cube.Initialize(spawnPoint, Vector3.down);
    }
}
