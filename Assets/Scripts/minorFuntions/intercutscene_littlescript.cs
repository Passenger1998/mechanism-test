using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class intercutscene_littlescript : MonoBehaviour
{

    VideoPlayer video;

    void Awake()
    {
        video = GetComponent<VideoPlayer>();
        video.Play();
        video.loopPointReached += CheckOver;


    }


    void CheckOver(UnityEngine.Video.VideoPlayer vp)
    {
        SceneManager.LoadScene("Level333");//the scene that you want to load after the video has ended.
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene("Level333");
        }
    }

}