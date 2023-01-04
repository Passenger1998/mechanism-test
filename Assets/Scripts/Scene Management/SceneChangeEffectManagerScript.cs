using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.UIElements;
using static AllSceneManager;
using static UnityEditor.Recorder.OutputPath;


public class SceneChangeEffectManagerScript : MonoBehaviour
{


    public Animator sceneTransit_Animator;

    float timeAwaits;
    public float timeToWait_BeforeStart;
    public GameObject blackcover;
    public GameObject blackcover_1;

    float timeElapsed;
    public float lerpDuration = 3.0f;
    float startValue;
    float endValue = 179.0f;
    float valueToLerp;

    public Camera cam;

    public string nextSceneName;

    bool SceneisFadingout_andTransit = false;
    bool SceneisjustFadingtoBlack = false;

    public GameObject deaddisplay;
    public GameObject slaughtercountDisplay;

    bool gononwithdeadactions = false;
    public GameObject _UI;
    

    private void OnEnable()
    {
        AllSceneManager.SceneStart += ScenePause;
        PlayerSensorScript.BeingTeleported += SceneFadeout_and_teleport;
        PlayerGlobalCondition.PlayerisDead += PlayerDeathScreen;
    }

    private void OnDisable()
    {
        AllSceneManager.SceneStart -= ScenePause;
        PlayerSensorScript.BeingTeleported -= SceneFadeout_and_teleport;
        PlayerGlobalCondition.PlayerisDead -= PlayerDeathScreen;
    }

    void ScenePause()
    {
        blackcover.SetActive(true);

        timeAwaits += Time.deltaTime;
        if (timeAwaits >= timeToWait_BeforeStart)
        {
            SceneFadein();
            AllSceneManager._AllSceneManager._SceneState = AllSceneManager.SceneState.Running_;
        }
    }

    void SceneFadein()
    {
        blackcover.SetActive(false);
        sceneTransit_Animator.Play("fade in");
    }

    void SceneFadeout_and_teleport()
    {

        SceneisFadingout_andTransit = true;

        //while (timeElapsed < lerpDuration) 
        //{
        //    timeElapsed += Time.deltaTime;
        //}

        //if (timeElapsed < lerpDuration)
        //{
        //    valueToLerp = Mathf.Lerp(startValue, endValue, timeElapsed / lerpDuration);
        //    //timeElapsed += Time.deltaTime;
        //    cam.fieldOfView = valueToLerp;

        //    //Debug.Log("Fade amount: "+ valueToLerp +" : "+ cam.fieldOfView);
        //}


        //if (timeElapsed < lerpDuration)
        //{
        //    valueToLerp = Mathf.Lerp(startValue, endValue, timeElapsed / lerpDuration);
        //    timeElapsed += Time.deltaTime;
        //    cam.fieldOfView = valueToLerp;

        //    //Debug.Log("Fade amount: "+ valueToLerp +" : "+ cam.fieldOfView);
        //}
        //if (timeElapsed >= lerpDuration)
        //{
        //    //Debug.Log("Fade complete");
        //    cam.fieldOfView = endValue;
        //    sceneTransit_Animator.Play("fade out");
        //    AllSceneManager._AllSceneManager.ShiftScene(nextSceneName);

        //}
    }

    private void Start()
    {
        startValue = cam.GetComponent<Camera>().fieldOfView;
        AllSceneManager._AllSceneManager._SceneState = AllSceneManager.SceneState.Start_;
    }

    private void Update()
    {
        if (SceneisFadingout_andTransit)
        {
            if (timeElapsed < lerpDuration)
            {
                valueToLerp = Mathf.Lerp(startValue, endValue, timeElapsed / lerpDuration);
                timeElapsed += Time.deltaTime;
                cam.fieldOfView = valueToLerp;
                sceneTransit_Animator.Play("fade out");

                //Debug.Log("Fade amount: "+ valueToLerp +" : "+ cam.fieldOfView);
            } else if (timeElapsed >= lerpDuration)
            {
                //Debug.Log("Fade complete");
                cam.fieldOfView = endValue;
                

                AllSceneManager._AllSceneManager.ShiftScene(nextSceneName);

            }
        }

        if (SceneisjustFadingtoBlack)
        {
            if (timeElapsed < lerpDuration)
            {
                valueToLerp = Mathf.Lerp(startValue, endValue, timeElapsed / lerpDuration);
                timeElapsed += Time.deltaTime;
                cam.fieldOfView = valueToLerp;
                sceneTransit_Animator.Play("fade out");

                //Debug.Log("Fade amount: "+ valueToLerp +" : "+ cam.fieldOfView);
            }
            else if (timeElapsed >= lerpDuration)
            {
                //Debug.Log("Fade complete");
                cam.fieldOfView = endValue;
                blackcover_1.SetActive(true);
                gononwithdeadactions = true;
                SceneisjustFadingtoBlack = false;
                //sceneTransit_Animator.StopPlayback();

            }
        }
    }

    void PlayerDeathScreen()
    {
        _UI.SetActive(false);
        SceneisjustFadingtoBlack = true;

        if (gononwithdeadactions)
        {
            
            if (Input.GetMouseButtonDown(0))
            {
                AllSceneManager._AllSceneManager.RespawntoCurrentScene();
            }
            else if (Input.GetMouseButtonDown(1))
            {
                AllSceneManager._AllSceneManager.ShiftScene("Main Menu");
            }

            deaddisplay.SetActive(true);
            slaughtercountDisplay.gameObject.GetComponent<Text>().text = "After slaughtering " + PlayerGlobalCondition._PlayerGlobalCondition.killcount + " monsters...";
        }
    }

}
