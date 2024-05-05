using System.Collections;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Transform _platform;
    [SerializeField] private CubePool _pool;

    private float _positionX;
    private float _positionZ;
    private float _positionY = 100f;
    private float _waitTime = 0.5f;
    private WaitForSeconds _wait;

    private void Start()
    {
        _positionX = _platform.localScale.x * 5;
        _positionZ = _platform.localScale.z * 5;
        transform.position = new Vector3(_platform.position.x, _platform.position.y + _positionY, _platform.position.z);
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

        Cube cube = _pool.GetCube();
        cube.gameObject.SetActive(true);
        cube.transform.position = spawnPoint;
        cube.Rigidbody.velocity = Vector3.down * cube.Speed;
        cube.Recolour(cube.DefaultColor);
    }
}
