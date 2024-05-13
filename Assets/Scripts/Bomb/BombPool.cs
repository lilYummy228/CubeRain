using UnityEngine;

public class BombPool : MonoBehaviour
{
    [SerializeField] private Bomb _bomb;
    [SerializeField] private Transform _container;

    private ObjectPool<Bomb> _bombPool;

    private void Awake()
    {
        _bombPool = new ObjectPool<Bomb>(_bomb, _container);
    }

    public Bomb GetBomb()
    {
        Bomb bomb = _bombPool.GetObject();
        bomb.Exploded += PutBomb;

        return bomb;
    }


    public void PutBomb(Bomb bomb)
    {
        _bombPool.PutObject(bomb);
        bomb.Exploded -= PutBomb;
    }
}
