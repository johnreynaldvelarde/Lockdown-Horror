using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class IntroLogoVideoManager : MonoBehaviour
{
    [SerializeField]
    private string nextSceneName; 

    private VideoPlayer videoPlayer;

    private void Start()
    {
        videoPlayer = GetComponent<VideoPlayer>();
        videoPlayer.loopPointReached += OnVideoEnd; 
    }

    private void OnVideoEnd(VideoPlayer vp)
    {
        SceneManager.LoadScene(nextSceneName);
    }
}
