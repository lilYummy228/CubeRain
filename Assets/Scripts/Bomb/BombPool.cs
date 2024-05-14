using System;
using UnityEngine;

public class BombPool : MonoBehaviour
{
    private const int Unit = 1;

    [SerializeField] private Bomb _bomb;
    [SerializeField] private Transform _container;

    private ObjectPool<Bomb> _bombPool;

    public event Action<int> BombCountChanged;

    private void Awake()
    {
        _bombPool = new ObjectPool<Bomb>(_bomb, _container);
    }

    public Bomb GetBomb()
    {
        Bomb bomb = _bombPool.GetObject();
        bomb.Exploded += PutBomb;

        BombCountChanged?.Invoke(Unit);

        return bomb;
    }


    public void PutBomb(Bomb bomb)
    {
        _bombPool.PutObject(bomb);
        bomb.Exploded -= PutBomb;

        BombCountChanged?.Invoke(-Unit);
    }
}
