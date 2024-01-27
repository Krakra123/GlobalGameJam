using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class VideoPlayerHandler : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] VideoClip[] m_clip;
    [SerializeField] GameObject VideoPlayerUI;
    private VideoPlayer videoPlayer;
    private bool IsStarted = false;
    


    void Start()
    {
      videoPlayer = GetComponent<VideoPlayer>();
    }

    // Update is called once per frame
    void Update()
    {
        if(videoPlayer != null)
        {
            if(videoPlayer.isPlaying && IsStarted == false)
            {
                IsStarted = true;
            }
            if (!videoPlayer.isPlaying && IsStarted == true) {
                VideoPlayerUI.gameObject.SetActive(false);
            }
        }
    }

    public  void SetToNextClip(int index)
    {
        VideoPlayerUI.gameObject.SetActive(true);
        videoPlayer.clip = m_clip[index];
        videoPlayer.Play();
    } 

}
