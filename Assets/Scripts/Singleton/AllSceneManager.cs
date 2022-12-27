using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AllSceneManager : MonoBehaviour
{

    public static AllSceneManager _AllSceneManager;
    public static event Action SceneStart;
    public static event Action SceneRunning;
    public static event Action SceneFinish;
    public static event Action SceneNotActive;
    public enum SceneState { Start_, Running_, Finish_, NotActive_ }
    public SceneState _SceneState = SceneState.NotActive_;

    public static event Action TeleportStart;
    public static event Action TeleportEnd;
    public bool isTeleporting_ = false;


    // Start is called before the first frame update
    public void OnEnable()
    {
        if (_AllSceneManager != null && _AllSceneManager != this)
        {
            Destroy(this);
        }
        else
        {
            _AllSceneManager = this;
        }

       _SceneState = SceneState.NotActive_;


    }



    public void SceneStateChanger()
    {
        switch (_SceneState)
        {
            case SceneState.NotActive_ :
                {
                    SceneNotActive?.Invoke();
                }
                break;
            case SceneState.Start_:
                {
                    SceneStart?.Invoke();
                }
                break;
            case SceneState.Running_:
                {
                    SceneRunning?.Invoke();
                }
                break;
            case SceneState.Finish_:
                {
                    SceneFinish?.Invoke();
                }
                break;
        }
        
    }

    public void ShiftScene(string nextSceneName)
    {
        AllSceneManager._AllSceneManager.isTeleporting_ = false;
        SceneManager.LoadScene(nextSceneName);
    }

    // Update is called once per frame
    private void Start()
    {

        
    }

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
            //Debug.Log("exit is pressed");
        }

        SceneStateChanger();

    }

}
