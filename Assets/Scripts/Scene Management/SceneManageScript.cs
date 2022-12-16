using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SceneManageScript : MonoBehaviour
{

    static public SceneManageScript Instance;

    public Animator sceneTransit_Animator;


    /// <summary>
    /// VARIABLES FOR SCENE STATE SWITCHER
    public enum SceneLoadManager { StartRunning, Running_, FinishRunning }
    public SceneLoadState SceneLoadManager_;

    public enum SceneLoadState { NotActive, InProgress, Done }
    public SceneLoadState StartSceneState_ = SceneLoadState.NotActive;
    public SceneLoadState EndSceneState_ = SceneLoadState.NotActive;

    ///VARIABLES SETTINGS FOR _StartSceneState_()
    float timeAwaits;
    public float timeToWait_BeforeStart;
    public GameObject blackcover;
    
    /// VARIABLES SETTINGS FOR "_EndSceneState_()"
    float timeElapsed;
    public float lerpDuration = 3.0f;
    float startValue;
    float endValue = 179.0f;
    float valueToLerp;



    public Camera cam;

    

    /// BOOL FOR CONTROL ACCESS:
    public bool isPlayerControllable;

    /// </summary>




    /// <summary>
    /// FUNCTIONS

    public void OnEnable()
    {
        Instance = this;

        StartSceneState_ = SceneLoadState.NotActive;
        
    }
    public void Exit()
    {
        Application.Quit();
    }

    public void ChangeScene(string scene)
    {
        SceneManager.LoadScene(scene);
    }

    public void _StartSceneState_()
    {
        switch (StartSceneState_)
        {
            case SceneLoadState.NotActive:
                {
                   
                    blackcover.SetActive(true);

                    timeAwaits += Time.deltaTime;
                    if (timeAwaits >= timeToWait_BeforeStart)
                    {
                        StartSceneState_ = SceneLoadState.InProgress;
                    }

                }
                break;
            case SceneLoadState.InProgress:
                {
                    blackcover.SetActive(false);
                    sceneTransit_Animator.Play("fade in");
                }
                break;
            case SceneLoadState.Done:
                {

                }
                break;
            default:
                {

                }
                break;
        }
    }

    public void _EndSceneState_()
    {
        switch (EndSceneState_)
        {
            case SceneLoadState.NotActive:
                {

                    //EndSceneState_ = SceneLoadState.InProgress;
                    //timeElapsed = 0.0f;
                }
                break;
            case SceneLoadState.InProgress:
                {
                    //Debug.Log("fade in progress");
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
                        EndSceneState_ = SceneLoadState.Done;
                    }

                }
                break;
            case SceneLoadState.Done:
                {

                    SceneManageScript.Instance.ChangeScene("Level333");

                }
                break;
            default:
                {

                }
                break;
        }
    }
    /// </summary>

    // Start is called before the first frame update
    

    
    public void Start()
    {

        startValue = cam.GetComponent<Camera>().fieldOfView;

        EndSceneState_ = SceneLoadState.NotActive;


    }

    // Update is called once per frame
    public void Update()
    {
        if(Input.GetKeyUp(KeyCode.Escape))
        {
            Exit();
        }

        _StartSceneState_();

        _EndSceneState_();

    }


}
