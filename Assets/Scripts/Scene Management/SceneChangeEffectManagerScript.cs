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
    

    private void OnEnable()
    {
        AllSceneManager.SceneNotActive += ScenePause;
        SceneStart += SceneFadein;
        PlayerConditionScript.BeingTeleported += SceneFadeout;
    }

    private void OnDisable()
    {
        AllSceneManager.SceneNotActive -= ScenePause;
        SceneStart -= SceneFadein;
        PlayerConditionScript.BeingTeleported -= SceneFadeout;
    }

    void ScenePause()
    {
        blackcover.SetActive(true);

        timeAwaits += Time.deltaTime;
        if (timeAwaits >= timeToWait_BeforeStart)
        {
            AllSceneManager._AllSceneManager._SceneState = AllSceneManager.SceneState.Start_;
        }
    }

    void SceneFadein()
    {
        blackcover.SetActive(false);
        sceneTransit_Animator.Play("fade in");
    }

    void SceneFadeout()
    {


        if (timeElapsed < lerpDuration)
        {
            valueToLerp = Mathf.Lerp(startValue, endValue, timeElapsed / lerpDuration);
            timeElapsed += Time.deltaTime;
            cam.fieldOfView = valueToLerp;

            //Debug.Log("Fade amount: "+ valueToLerp +" : "+ cam.fieldOfView);
        }
        else
        {
            //Debug.Log("Fade complete");
            cam.fieldOfView = endValue;
            sceneTransit_Animator.Play("fade out");
            AllSceneManager._AllSceneManager.ShiftScene(nextSceneName);

        }
    }

    private void Start()
    {
        startValue = cam.GetComponent<Camera>().fieldOfView;
    }

}
