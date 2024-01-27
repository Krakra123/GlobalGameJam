using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class CutsceneManager : GenericSingleton<CutsceneManager>
{
    [SerializeField] 
    private RawImage _videoPlayerUI;

    [SerializeField]
    private VideoPlayer _videoPlayer;
    
    [SerializeField] 
    private VideoClip[] _clips;

    public bool IsPlaying { get => _videoPlayer.isPlaying; }

    private void Start()
    {
        _videoPlayer = GetComponent<VideoPlayer>();
        _videoPlayerUI.gameObject.SetActive(false);
    }

    public void Play(int index)
    {
        _videoPlayerUI.gameObject.SetActive(true);

        _videoPlayer.clip = _clips[index];
        _videoPlayer.Play();
    }

    public void Stop(int index)
    {
        _videoPlayerUI.gameObject.SetActive(false);

        _videoPlayer.Stop();
    }
}
