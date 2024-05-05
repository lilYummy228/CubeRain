using UnityEngine;

[RequireComponent(typeof(MeshRenderer), typeof(Rigidbody))]
public class Cube : MonoBehaviour
{
    [SerializeField] private float _speed;

    private MeshRenderer _meshRenderer;

    public Rigidbody Rigidbody { get; private set; }
    public Color DefaultColor { get; private set; }
    public float Speed => _speed;

    private void Awake()
    {
        _meshRenderer = GetComponent<MeshRenderer>();
        Rigidbody = GetComponent<Rigidbody>();
        DefaultColor = Color.blue;

        Recolour(DefaultColor);
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.TryGetComponent(out Platform platform) && _meshRenderer.material.color == DefaultColor)
        {
            Recolour(new Color(Random.Range(0, 1f), Random.Range(0, 1f), Random.Range(0, 1f)));

            StartCoroutine(platform.ReturnInPool(this));
        }
    }

    public void Recolour(Color color)
    {
        _meshRenderer.material.color = color;
    }
}
