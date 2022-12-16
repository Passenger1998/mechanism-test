using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SimpleSceneChangerScript : MonoBehaviour
{

    float timeElapsed;
    float lerpDuration = 3;
    float startValue;
    float endValue = 179;
    float valueToLerp;

    bool startTeleport;

    Camera cam;

    enum SceneLoadState { NotActive, InProgress, Done}
    SceneLoadState _State;

    // Start is called before the first frame update
    void Start()
    {

        cam = GameObject.FindObjectOfType<Camera>();
       
        startTeleport = false;

        startValue = cam.GetComponent<Camera>().fieldOfView;
    }

    void Update()
    {
        switch (_State)
        {
            case SceneLoadState.NotActive:
                {
                    if(startTeleport)
                    {
                        _State = SceneLoadState.InProgress;
                    }
                }
                break;
            case SceneLoadState.InProgress:
                {
                    if (timeElapsed < lerpDuration)
                    {
                        valueToLerp = Mathf.Lerp(startValue, endValue, timeElapsed / lerpDuration);
                        timeElapsed += Time.deltaTime;
                        cam.GetComponent<Camera>().fieldOfView = valueToLerp;
                    }
                    else
                    {
                        _State = SceneLoadState.Done;
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

    void OnTriggerEnter(Collider col)
    {

        startTeleport = true;

            //SceneManageScript.Instance.ChangeScene("Level333");
           
           //SceneManager.LoadScene("Level333");
        }

    }

}
