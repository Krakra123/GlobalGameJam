using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Response : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI _textGUI;

    [SerializeField]
    private Button _responseButton;
    public Button ResponseButton { get => _responseButton; }

    private string _text;

    public void SetUp(string text)
    {
        _text = text;
        _textGUI.text = _text;
    }
}