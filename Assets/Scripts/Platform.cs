using System.Collections;
using UnityEngine;

public class Platform : MonoBehaviour
{
    [SerializeField] private CubePool _pool;

    private float _minLifeTime = 2f;
    private float _maxLifeTime = 5f;
    private WaitForSeconds _wait;

    public IEnumerator ReturnInPool(Cube cube)
    {
        _wait = new WaitForSeconds(Random.Range(_minLifeTime, _maxLifeTime));
        yield return _wait;

        _pool.PutCube(cube);
    }
}
