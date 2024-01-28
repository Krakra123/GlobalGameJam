using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
    private void Start()
    {
        AudioManager.Instance.PlaySound(GameSound.BGM);
    }
}
