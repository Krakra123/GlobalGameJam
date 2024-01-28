using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(
    fileName = "ChatContainer", menuName = "Scriptable Objects/ChatContainer", order = 1
)]
public class ChattingContainer : ScriptableObject
{
    public List<TextAsset> Data;
}