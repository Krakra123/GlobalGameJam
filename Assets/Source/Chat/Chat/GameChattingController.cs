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
    private ChattingContainer _stateContainer;

    [SerializeField]
    private MessageManager _messageManager;

    [SerializeField]
    private ResponseManager _responseManager;

    private Story _currentStory;

    private ChatState _currentState;

    private void Start()
    {
        SetState("Test");
    }

    private void Update()
    {
        if (_currentState == ChatState.Chatting && Input.GetMouseButtonDown(0))
        {
            ProgressStory(false);
        }
    }

    public void ProgressStory(bool isOwn)
    {
        if (_currentState == ChatState.Chatting)
        {
            if (_currentStory.canContinue)
            {
                string text = _currentStory.Continue(); 
                _messageManager.LoadMessage(text, isOwn);
            }
            else if (_currentStory.currentChoices.Count > 0)
            {
                _currentState = ChatState.Responsing;

                for (int i = 0; i < _currentStory.currentChoices.Count; i++)
                {
                    var choice = _currentStory.currentChoices[i];
                    Button button = _responseManager.LoadResponse(choice.text);

                    // button.onClick.AddListener(() => SelectResponse(i));
                }
            }
        }
    }

    public void SelectResponse(int index)
    {
        //_messageManager.LoadMessage(_currentStory.currentChoices[index].text, true);
        _currentStory.ChooseChoiceIndex(index);

        _responseManager.HideResponses();
        _currentState = ChatState.Chatting;
        ProgressStory(true);
    }

    public bool SetState(string stateName)
    {
        string data = "";
        if (!GetState(stateName, out data))
        {
            Debug.Log($"State data not found");
            return false;
        }

        _currentStory = new Story(data);
        // UpdateEvent();

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

    private bool GetState(string stateName, out string data)
    {
        foreach (TextAsset stateData in _stateContainer.Data)
        {
            if (stateData.name == stateName)
            {
                data = stateData.text;
                return true;
            }
        }

        data = "";
        return false;
    }
}
