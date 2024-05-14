using UnityEngine;

public class Spawner<T> where T : MonoBehaviour
{
    private View _view;
    private int _spawnedCount = 0;

    public Spawner(View view)
    {
        _view = view;
    }

    public void Spawn(Vector3 spawnPoint, T gameObject)
    {        
        gameObject.gameObject.SetActive(true);
        gameObject.transform.position = spawnPoint;

        _view.ShowInfo(++_spawnedCount);
    }
}
