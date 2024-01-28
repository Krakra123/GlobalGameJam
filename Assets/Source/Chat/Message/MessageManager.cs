using System.Collections.Generic;
using UnityEngine;

public class MessageManager : MonoBehaviour
{
    [SerializeField]
    private GameObject _ownMessagePrototype;
    [SerializeField]
    private GameObject _otherMessagePrototype;

    [SerializeField]
    private MessagePool _messagePool;

    [Header("Chat Config")]
    [SerializeField]
    private int _maxMessages;

    [SerializeField]
    private float _messageSpacingOffset;

    private Vector2 _chatOrigin;
    private float _chatWidth;

    [Header("Message Config")]
    [SerializeField]
    private float _messageMaxWidth;
    public float MessageMaxWidth { get => _messageMaxWidth; }
    [SerializeField]
    private float _messageLineSpacing;
    public float MessageLineSpacing { get => _messageLineSpacing; }

    [SerializeField]
    private float _messageBoundOffset;
    public float MessageBoundOffset { get => _messageBoundOffset; }

    [SerializeField]
    private float _messageTextHorizontalOffset;
    public float MessageTextHorizontalOffset { get => _messageTextHorizontalOffset; }

    private LinkedList<Message> _messageList = new();
    private Message _currentPendingMessage;

    private void Start()
    {
        _chatOrigin = transform.position;
        _chatWidth = GetComponent<RectTransform>().rect.width;
    }

    public void LoadMessage(string text, bool isOwnMessage)
    {
        Message messageInstance = CreateMassageRaw(text, isOwnMessage);

        _messageList.AddLast(messageInstance);

        if (_messageList.Count > _maxMessages)
        {
            DeleteMassageRaw(_messageList.First.Value);
            _messageList.RemoveFirst();
        }
    }

    public void CreatePendingMessage(bool isOwnMessage)
    {
        _currentPendingMessage = CreateMassageRaw("... ▼", isOwnMessage);
    }
    public void RemovePendingMessage()
    {
        if (_currentPendingMessage == null) return;

        Vector2 poolPosition = _messagePool.transform.position;
        poolPosition.y -= _currentPendingMessage.SpacingHeight + _messageSpacingOffset;
        _messagePool.transform.position = poolPosition;

        _messagePool.Release(_currentPendingMessage);
        _currentPendingMessage = null;
    }

    private Message CreateMassageRaw(string text, bool isOwn)
    {
        if (isOwn)
            _messagePool.SetPrototype(_ownMessagePrototype);
        else
            _messagePool.SetPrototype(_otherMessagePrototype);

        Message messageInstance = _messagePool.Get();

        Vector2 messagePosition = _chatOrigin;
        if (isOwn) messagePosition += Vector2.right * _chatWidth;
        messageInstance.SetUp(this, text, messagePosition);

        Vector2 poolPosition = _messagePool.transform.position;
        poolPosition.y += messageInstance.SpacingHeight + _messageSpacingOffset;
        _messagePool.transform.position = poolPosition;

        return messageInstance;
    }

    private void DeleteMassageRaw(Message message)
    {
        _messagePool.Release(message);
    }
}
