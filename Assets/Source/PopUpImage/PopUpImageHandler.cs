using UnityEngine;
using UnityEngine.UI;

public class PopUpImageHandler : MonoBehaviour
{
    [SerializeField] 
    private Image _image;

    private void Start()
    {
        _image.gameObject.SetActive(false);
    }

    public void LoadImage(Sprite image)
    {
        _image.GetComponent<SpriteRenderer>().sprite = image;
    }

    public void ShowImage()
    {
        _image.gameObject.SetActive(true);
    }

    public void HideImage()
    {
        _image.gameObject.SetActive(false);
    }
}
