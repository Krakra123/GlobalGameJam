using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(
    fileName = "StateContainer", menuName = "Scriptable Objects/StateContainer", order = 1
)]
public class GameStateContainer : ScriptableObject
{
    public List<TextAsset> Data;
}