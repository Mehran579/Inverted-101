using UnityEngine;
using UnityEngine.Video;

public class videoplayer : MonoBehaviour
{
    void Start()
    {
        VideoPlayer vp = GetComponent<VideoPlayer>();
        vp.url = System.IO.Path.Combine(Application.streamingAssetsPath, "184365-873181583.mp4");
        vp.Play(); 
    }
}
