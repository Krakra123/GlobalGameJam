using UnityEngine;
using TMPro;

public class Message : MonoBehaviour
{
    private MessageManager _manager;

    [SerializeField]
    private TextMeshProUGUI _textGUI;

    private string _text;

    [HideInInspector]
    public float SpacingHeight;

    public void SetUp(MessageManager manager, string text, Vector2 position)
    {
        _manager = manager;

        _text = text;
        _textGUI.GetComponent<RectTransform>().sizeDelta = new Vector2(_manager.MessageMaxWidth - _manager.MessageTextHorizontalOffset - 10f, 0f);
        _textGUI.text = _text;

        Canvas.ForceUpdateCanvases();

        int lineNum = _textGUI.textInfo.lineCount;
        if (lineNum > 1)
        {
            GetComponent<RectTransform>().sizeDelta = new Vector2(manager.MessageMaxWidth, lineNum * _manager.MessageLineSpacing + _manager.MessageBoundOffset * 2f);
        }
        else 
        {
            GetComponent<RectTransform>().sizeDelta = new Vector2(
                // manager.MessageMaxWidth,
                _textGUI.textBounds.size.x + _manager.MessageTextHorizontalOffset + 10f, 
                lineNum * _manager.MessageLineSpacing + _manager.MessageBoundOffset * 2f
                );
        }

        SpacingHeight = lineNum * _manager.MessageLineSpacing + _manager.MessageBoundOffset * 2f;

        transform.position = position + Vector2.down * SpacingHeight;
    }
}