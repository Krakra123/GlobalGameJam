using UnityEngine;

public class MessagePool : MonoBehaviour
{
    private GameObject _prototype;
    public void SetPrototype(GameObject gameObject)
    {
        _prototype = gameObject;
    }

    public Message Get()
    {
        Message instance = Instantiate(_prototype).GetComponent<Message>();
        instance.transform.SetParent(this.transform);
        return instance;
    }

    public void Release(Message instance)
    {
        Destroy(instance.gameObject);
    }
}