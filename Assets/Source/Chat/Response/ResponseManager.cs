using UnityEngine;
using UnityEngine.UI;

public class ResponseManager : MonoBehaviour
{
    [SerializeField]
    private Response[] _responses;

    // private bool _isResponsing;
    // public bool IsResponsing { get => _isResponsing; }

    private int _responseCount;

    private void Start()
    {
        HideResponses();
    }

    public Button LoadResponse(string text)
    {
        int index = _responseCount++;

        _responses[index].gameObject.SetActive(true);
        _responses[index].SetUp(text);

        return _responses[index].ResponseButton;
    }

    public void HideResponses()
    {
        foreach (Response responseInstance in _responses)
        {
            if (responseInstance.gameObject.activeInHierarchy)
            {
                responseInstance.gameObject.SetActive(false);
            }
        }
        _responseCount = 0;
    }
}