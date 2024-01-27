using System.Collections.Generic;
using UnityEngine;

public class DisplayMessageManager : MonoBehaviour
{
    [SerializeField]
    private GameObject _otherMessagePrototype;
    [SerializeField]

    private GameObject _ownMessagePrototype;

    [SerializeField]
    private MessagePool _messagePool;

    [Header("Config")]
    [SerializeField]
    private int _maxMessages;

    [SerializeField]
    private float _messageSpacing;

    [SerializeField]
    private Vector2 _chatOrigin;
    [SerializeField]
    private float _chatWidth;

    private LinkedList<Message> _messageList = new();

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            LoadMessage(Time.time.ToString(), false);
        }
        if (Input.GetKeyDown(KeyCode.B))
        {
            LoadMessage(Time.time.ToString(), true);
        }
    }

    private void Start()
    {
        _messagePool.SetPrototype(_otherMessagePrototype); //!
    }

    public void LoadMessage(string text, bool isOwnMessage)
    {
        Message messageInstance = null;
        if (!isOwnMessage) 
            messageInstance = CreateOtherMassageRaw(text);
        else 
            messageInstance = CreateOwnMassageRaw(text);

        _messageList.AddLast(messageInstance);

        if (_messageList.Count > _maxMessages)
        {
            DeleteMassageRaw(_messageList.First.Value);
            _messageList.RemoveFirst();
        }
    }

    private Message CreateOtherMassageRaw(string text)
    {
        Vector2 poolPosition = _messagePool.transform.position;
        poolPosition.y += _messageSpacing;
        _messagePool.transform.position = poolPosition;

        _messagePool.SetPrototype(_otherMessagePrototype);
        Message messageInstance = _messagePool.Get();
        messageInstance.SetUp(text, _chatOrigin);

        return messageInstance;
    }
    private Message CreateOwnMassageRaw(string text)
    {
        Vector2 poolPosition = _messagePool.transform.position;
        poolPosition.y += _messageSpacing;
        _messagePool.transform.position = poolPosition;

        _messagePool.SetPrototype(_ownMessagePrototype);
        Message messageInstance = _messagePool.Get();
        messageInstance.SetUp(text, _chatOrigin + Vector2.right * _chatWidth);

        return messageInstance;
    }

    private void DeleteMassageRaw(Message message)
    {
        // Vector2 poolPosition = _messagePool.transform.position;
        // poolPosition.y -= _messageSpacing;
        // _messagePool.transform.position = poolPosition;
        _messagePool.Release(message);
    }
}
