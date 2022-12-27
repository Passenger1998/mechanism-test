using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class ActionAfterVideoScript : MonoBehaviour
{

    public GameObject background_videoplayer;

    public double time;
    public double currentTime;

    // Start is called before the first frame update


    // Update is called once per frame
    void Start()
    {

        time = background_videoplayer.gameObject.GetComponent<VideoPlayer>().clip.length;
        background_videoplayer.gameObject.GetComponent<VideoPlayer>().Play();
    }

    // Update is called once per frame
    public void TeleportAfterVideo()
    {
        currentTime = background_videoplayer.gameObject.GetComponent<VideoPlayer>().time;
        background_videoplayer.gameObject.GetComponent<VideoPlayer>().Play();

        if (currentTime >= time)
        {

            AllSceneManager._AllSceneManager.ShiftScene("BeforePlay CutScene");
        }

       
    }
}
