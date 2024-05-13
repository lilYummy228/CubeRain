using System;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

[RequireComponent(typeof(MeshRenderer), typeof(Rigidbody))]
public class Cube : MonoBehaviour
{
    [SerializeField] private float _speed;

    private MeshRenderer _meshRenderer;
    private Rigidbody _rigidbody;
    private WaitForSeconds _wait;
    private Color _defaultColor;
    private float _minLifeTime = 2f;
    private float _maxLifeTime = 5f;

    public event Action<Cube> Landed;

    private void Awake()
    {
        _meshRenderer = GetComponent<MeshRenderer>();
        _rigidbody = GetComponent<Rigidbody>();
        _defaultColor = Color.blue;

        Recolour(_defaultColor);
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.TryGetComponent(out Platform platform) && _meshRenderer.material.color == _defaultColor)
        {
            Recolour(new Color(Random.Range(0, 1f), Random.Range(0, 1f), Random.Range(0, 1f)));

            StartCoroutine(nameof(Delay));            
        }
    }

    private IEnumerator Delay()
    {
        _wait = new WaitForSeconds(Random.Range(_minLifeTime, _maxLifeTime));
        yield return _wait;

        Landed?.Invoke(this);
    }

    public void Recolour(Color color)
    {
        _meshRenderer.material.color = color;
    }

    public void Init(Vector3 position, Vector3 direction)
    {
        transform.position = position;
        _rigidbody.velocity = direction * _speed;

        Recolour(_defaultColor);
    }
}
