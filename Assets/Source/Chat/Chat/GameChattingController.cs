using UnityEngine;
using Ink.Runtime;
using UnityEngine.UI;
using System.Collections.Generic;

public class GameChattingController : MonoBehaviour
{
    private enum ChatState
    {
        Chatting,
        Responsing
    }

    [SerializeField]
    private ChattingContainer _chatContainer;

    [SerializeField]
    private MessageManager _messageManager;

    [SerializeField]
    private ResponseManager _responseManager;

    private Story _currentStory;

    private ChatState _currentState;

    private void Start()
    {
        SetChat("Test");
    }

    private void Update()
    {
        if (_currentState == ChatState.Chatting && Input.GetMouseButtonDown(0))
        {
            ProgressChat(false);
        }
    }

    public void ProgressChat(bool isOwn)
    {
        if (_currentState == ChatState.Chatting)
        {
            if (_currentStory.canContinue)
            {
                string text = _currentStory.Continue(); 

                _messageManager.RemovePendingMessage();

                _messageManager.LoadMessage(text, isOwn);

                if (_currentStory.canContinue) 
                {
                    _messageManager.CreatePendingMessage(isOwn);
                }
                else 
                {
                    ProgressChat(isOwn);
                }
            }
            else if (_currentStory.currentChoices.Count > 0)
            {
                _currentState = ChatState.Responsing;

                for (int i = 0; i < _currentStory.currentChoices.Count; i++)
                {
                    var choice = _currentStory.currentChoices[i];
                    Button button = _responseManager.LoadResponse(choice.text);

                    // button.onClick.AddListener(() => SelectResponse(i)); //!
                }
            }
        }
    }

    public void SelectResponse(int index)
    {
        _currentStory.ChooseChoiceIndex(index);

        _responseManager.HideResponses();
        _currentState = ChatState.Chatting;
        ProgressChat(true);
    }

    public bool SetChat(string chatName)
    {
        string data = "";
        if (!GetChat(chatName, out data))
        {
            Debug.Log($"Chat data not found");
            return false;
        }

        _currentStory = new Story(data);
        UpdateEvent();

        return true;
    }

    private void UpdateEvent()
    {
        ChatEventList list = new ChatEventList();
        foreach (KeyValuePair<string, EventKey> pair in list.ChatEventKey)
        {
            string name = pair.Key;
            EventKey key = pair.Value;

            // Debug.Log($"{name} -> {key}");
            _currentStory.BindExternalFunction(name, () => EventDispatcher.Instance.PostEvent(key));
        }
    }

    private bool GetChat(string chatName, out string data)
    {
        foreach (TextAsset stateData in _chatContainer.Data)
        {
            if (stateData.name == chatName)
            {
                data = stateData.text;
                return true;
            }
        }

        data = "";
        return false;
    }
}
