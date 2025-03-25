using UnityEngine;
using UnityEngine.Video;
using UnityEngine.Networking;
using System.Collections;


public class WebGLvideoPlayer : MonoBehaviour
{

    [SerializeField] private string videoFileName = "yourvideo.mp4"; // Set video filename in Inspector
    private VideoPlayer videoPlayer;
    private string videoPath;

    void OnEnable()
    {  // Runs automatically when the GameObject is activated
        videoPlayer = GetComponent<VideoPlayer>();
        StartCoroutine(LoadAndPlayVideo());
    }

    IEnumerator LoadAndPlayVideo()
    {
        videoPath = System.IO.Path.Combine(Application.streamingAssetsPath, videoFileName);
        Debug.Log("Loading video from: " + videoPath);

        // UnityWebRequest is required for WebGL to load StreamingAssets
        UnityWebRequest request = UnityWebRequest.Get(videoPath);
        yield return request.SendWebRequest();

        if (request.result == UnityWebRequest.Result.Success)
        {
            videoPlayer.url = videoPath;
            videoPlayer.Prepare(); // Prepares the video before playing
            videoPlayer.prepareCompleted += OnVideoPrepared;
        }
        else
        {
            Debug.LogError("Failed to load video: " + request.error);
        }
    }

    void OnVideoPrepared(VideoPlayer vp)
    {
        Debug.Log("Video prepared, starting playback...");
        videoPlayer.Play();
    }
}
