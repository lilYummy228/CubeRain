using TMPro;
using UnityEngine;

public class Counter : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text;

    public void ShowInfo(int count)
    {
        _text.text = count.ToString();
    }
}
