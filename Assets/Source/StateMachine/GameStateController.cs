using UnityEngine;
using Ink.Runtime;

public class GameStateController : MonoBehaviour
{
    [SerializeField]
    private GameStateContainer _stateContainer;

    private Story _currentStory;

    public bool ChangeState(string stateName)
    {
        string data = "";
        if (GetState(stateName, out data))
        {
            Debug.Log($"State data not found");
            return false;
        }

        _currentStory = new Story(data);
        Debug.Log(data);

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
