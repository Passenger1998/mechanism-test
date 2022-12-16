using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SimpleSceneChangerScript : MonoBehaviour
{

    //float timeElapsed;
    //public float lerpDuration = 3.0f;
    //float startValue;
    //float endValue = 179.0f;
    //float valueToLerp;

    

    //public Camera cam;

    //enum SceneLoadManager { StartRunning, Running_, FinishRunning}
    //SceneLoadState SceneLoadManager_;

    //enum SceneLoadState { NotActive, InProgress, Done}
    //SceneLoadState StarSceneState_= SceneLoadState.NotActive;
    //SceneLoadState EndSceneState_= SceneLoadState.NotActive;

    //// Start is called before the first frame update
    //void Start()
    //{  


    //    startValue = cam.GetComponent<Camera>().fieldOfView;
    //}

    //void Update()
    //{

    //    //switch (SceneLoadManager_)
    //    //{
    //    //    case SceneLoadManager.StartRunning:
    //    //    {

    //    //    }
    //    //    break;

    //    //}
      
    //    switch (EndSceneState_)
    //    {
    //        case SceneLoadState.NotActive:
    //            {
                     
    //                //EndSceneState_ = SceneLoadState.InProgress;
    //                //timeElapsed = 0.0f;
    //            }
    //            break;
    //        case SceneLoadState.InProgress:
    //            {
    //                //Debug.Log("fade in progress");
    //                if (timeElapsed < lerpDuration)
    //                {
    //                    valueToLerp = Mathf.Lerp(startValue, endValue, timeElapsed / lerpDuration);
    //                    timeElapsed += Time.deltaTime;
    //                    cam.fieldOfView = valueToLerp;
                        
    //                    //Debug.Log("Fade amount: "+ valueToLerp +" : "+ cam.fieldOfView);
    //                }
    //                else
    //                {
    //                    //Debug.Log("Fade complete");
    //                    cam.fieldOfView = endValue;
    //                    EndSceneState_ = SceneLoadState.Done;
    //                }

    //            }
    //            break;
    //        case SceneLoadState.Done:
    //            {
    //                SceneManageScript.Instance.ChangeScene("Level333");

    //            }
    //            break;
    //        default:
    //            {

    //            }
    //            break;
    //    }
        

       
    //}

    void OnTriggerEnter(Collider col)
    {

        //startTeleport = true;
        if(col.CompareTag("Player"))
        {
            SceneManageScript.Instance.EndSceneState_ = SceneManageScript.SceneLoadState.InProgress; 
        }
            //SceneManageScript.Instance.ChangeScene("Level333");

        //SceneManager.LoadScene("Level333");


    }
}

