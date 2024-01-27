using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(
    fileName = "ChattingContainer", menuName = "Scriptable Objects/ChattingContainer", order = 1
)]
public class ChattingContainer : ScriptableObject
{
    public List<TextAsset> Data;
}