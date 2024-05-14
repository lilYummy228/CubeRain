using UnityEngine;

public class Counter : MonoBehaviour
{
    [SerializeField] private BombPool _bombPool;
    [SerializeField] private CubePool _cubePool;
    [SerializeField] private View _view;

    private int _count;

    private void OnEnable()
    {
        _bombPool.BombCountChanged += CountActiveObjects;
        _cubePool.CubeCountChanged += CountActiveObjects;
    }

    private void OnDisable()
    {
        _bombPool.BombCountChanged -= CountActiveObjects;
        _cubePool.CubeCountChanged -= CountActiveObjects;
    }

    public void CountActiveObjects(int count)
    {
        _count += count;
        _view.ShowInfo(_count);
    }
}
