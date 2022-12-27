using Mono.Cecil.Cil;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class clickTransportScript : MonoBehaviour
{

    public string scene_name;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    public void Click_and_Transport()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            AllSceneManager._AllSceneManager.ShiftScene(scene_name);
        }
    }
}
