using UnityEngine;
using TMPro;

public class Message : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI _textGUI;

    private string _text;

    public void SetUp(string text, Vector2 position)
    {
        transform.position = position;
        _text = text;
        _textGUI.text = _text;
    }
}