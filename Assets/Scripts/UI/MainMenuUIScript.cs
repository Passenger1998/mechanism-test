using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.Events;

public class MainMenuUIScript : MonoBehaviour
{

    public GameObject background_videoplayer;
    public GameObject entrance_notice;
    public GameObject title_text;

    public Animator MainMenu_UIAnimator;

    public double time;
    public double currentTime;

    public string nextscene;

    // Start is called before the first frame update
    void Start()
    {

        time = background_videoplayer.gameObject.GetComponent<VideoPlayer>().clip.length;
        entrance_notice.gameObject.SetActive(false);
        title_text.gameObject.SetActive(true);
        background_videoplayer.gameObject.GetComponent<VideoPlayer>().Play();
        MainMenu_UIAnimator.Play("MainTitleAppears");


    }

    // Update is called once per frame
    void Update()
    {
        currentTime = background_videoplayer.gameObject.GetComponent<VideoPlayer>().time;


        if (currentTime >= time)
        {
            entrance_notice.gameObject.SetActive(true);
            
            if(Input.GetKeyDown(KeyCode.Return))
            {
                title_text.gameObject.SetActive(false);
                Destroy(entrance_notice);

                AllSceneManager._AllSceneManager.ShiftScene(nextscene);
            }
            // StartGame.Invoke();
            
        }
    }
}
