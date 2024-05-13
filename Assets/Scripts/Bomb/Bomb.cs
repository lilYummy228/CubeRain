using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshRenderer), typeof(Rigidbody))]
public class Bomb : MonoBehaviour
{
    private const float _zeroAlpha = 0f;
    private const float _fullAlpha = 1f;

    [SerializeField] private float _explosionRadius = 100f;
    [SerializeField] private float _explosionForce = 50f;
    [SerializeField] private Material _material;

    private Color _color;
    private WaitForSeconds _wait;
    private MeshRenderer _meshRenderer; 
    private float _minDelayTime = 2f;
    private float _maxDelayTime = 5f;
    private float _waitTime = 1f;
    private float _rate = 10f;

    public event Action<Bomb> Exploded;

    private void Awake()
    {
        _meshRenderer = GetComponent<MeshRenderer>();        

        _waitTime /= _rate;
        _wait = new WaitForSeconds(_waitTime);
    }

    private void OnEnable()
    {
        _meshRenderer.material = _material;
        _color = _meshRenderer.material.color;

        StartCoroutine(nameof(DelayExplosion));
    }

    private IEnumerator DelayExplosion()
    {
        float delayTime = UnityEngine.Random.Range(_minDelayTime, _maxDelayTime);
        float delay = Time.time + delayTime;

        while (delay >= Time.time)
        {
            Fade(_fullAlpha / delayTime / _rate);
            yield return _wait;
        }

        Explode();
    }

    private void Fade(float fadingTime)
    {
        _color.a = Mathf.MoveTowards(_color.a, _zeroAlpha, fadingTime);
        _meshRenderer.material.color = _color;
    }

    private void Explode()
    {
        foreach (Rigidbody explodableObjects in GetExplodableObjects())
            explodableObjects.AddExplosionForce(_explosionForce, transform.position, _explosionRadius);

        Exploded?.Invoke(this);
    }

    private List<Rigidbody> GetExplodableObjects()
    {
        Collider[] hits = Physics.OverlapSphere(transform.position, _explosionRadius);

        List<Rigidbody> explodableObjects = new();

        foreach (Collider hit in hits)
            if (hit.attachedRigidbody != null)
                explodableObjects.Add(hit.attachedRigidbody);

        return explodableObjects;
    }
}
