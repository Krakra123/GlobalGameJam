using UnityEngine;
using Ink.Runtime;
using UnityEngine.UI;

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
        ChangeState("Test");
    }

    private void Update()
    {
        Debug.Log(_currentState);
        if (_currentState == ChatState.Chatting && Input.GetKeyDown(KeyCode.E)) //TODO
        {
            if (_currentStory.canContinue)
            {
                string text = _currentStory.Continue(); 
                _messageManager.LoadMessage(text, false);
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
        _messageManager.LoadMessage(_currentStory.currentChoices[index].text, true);

        _currentStory.ChooseChoiceIndex(index);

        _responseManager.HideResponses();
        _currentState = ChatState.Chatting;
    }

    public bool ChangeState(string stateName)
    {
        string data = "";
        if (!GetState(stateName, out data))
        {
            Debug.Log($"State data not found");
            return false;
        }

        _currentStory = new Story(data);
        
        return true;
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
