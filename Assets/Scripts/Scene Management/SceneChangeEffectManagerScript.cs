using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;
using UnityEngine.SceneManagement;
using static AllSceneManager;


public class SceneChangeEffectManagerScript : MonoBehaviour
{


    public Animator sceneTransit_Animator;

    float timeAwaits;
    public float timeToWait_BeforeStart;
    public GameObject blackcover;

    float timeElapsed;
    public float lerpDuration = 3.0f;
    float startValue;
    float endValue = 179.0f;
    float valueToLerp;

    public Camera cam;

    public string nextSceneName;

    bool isSceneFadingOut = false;
    

    private void OnEnable()
    {
        AllSceneManager.SceneStart += ScenePause;
        PlayerConditionScript.BeingTeleported += SceneFadeout;
    }

    private void OnDisable()
    {
        AllSceneManager.SceneStart -= ScenePause;
        PlayerConditionScript.BeingTeleported -= SceneFadeout;
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

    void SceneFadeout()
    {

        isSceneFadingOut = true;

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


        ////if (timeElapsed < lerpDuration)
        ////{
        ////    valueToLerp = Mathf.Lerp(startValue, endValue, timeElapsed / lerpDuration);
        ////    timeElapsed += Time.deltaTime;
        ////    cam.fieldOfView = valueToLerp;

        ////    //Debug.Log("Fade amount: "+ valueToLerp +" : "+ cam.fieldOfView);
        ////}
        //if  (timeElapsed >= lerpDuration)
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
        if (isSceneFadingOut)
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
    }

}
