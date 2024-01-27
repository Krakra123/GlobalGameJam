using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopUpImageHandler : MonoBehaviour
{
    [SerializeField] GameObject Image;
    [SerializeField] GameObject button;

    // Start is called before the first frame update
    void Start()
    {
        Image.SetActive(false);
        button.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ShowImage()
    {
        Image.SetActive(true);
    }

    public void HideImage()
    {
        Image.SetActive(false);
    }
}
