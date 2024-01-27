using UnityEngine;
using TMPro;

public class Message : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI _textGUI;

    [SerializeField]
    private float _boxWidth;
    [SerializeField]
    private float _lineSpacing;
    [SerializeField]
    private float _boxBoundOffset;
    [SerializeField]
    private float _textHorizontalOffset;

    private string _text;

    [HideInInspector]
    public float SpacingHeight;

    public void SetUp(string text, Vector2 position)
    {
        _textGUI.GetComponent<RectTransform>().sizeDelta = new Vector2(_boxWidth - _textHorizontalOffset, 0f);
        _text = text;
        _textGUI.text = _text;

        Canvas.ForceUpdateCanvases();
        int lineNum = _textGUI.textInfo.lineCount;
        GetComponent<RectTransform>().sizeDelta = new Vector2(_boxWidth, lineNum * _lineSpacing + _boxBoundOffset * 2f);
        SpacingHeight = lineNum * _lineSpacing + _boxBoundOffset * 2f;

        transform.position = position + Vector2.down * SpacingHeight;
    }
}