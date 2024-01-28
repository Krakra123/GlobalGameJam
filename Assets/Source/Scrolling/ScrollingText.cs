using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScrollingText : MonoBehaviour
{
    [SerializeField] private string itemInfo;

    [Header("UI Elements")]
    [SerializeField] private TextMeshProUGUI itemInfoText;
    


    public void Load(string Text) 
    {
        itemInfo = Text;
    }

    public void Show()
    {
        itemInfoText.text = itemInfo;
    }

    public void SetGUI(TextMeshProUGUI target)
    {
        itemInfoText = target;
    }


}

