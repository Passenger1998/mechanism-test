using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class backDangerTriggerScript : MonoBehaviour
{
    public bool hasEntered;
    public bool handheldMode;

    // Start is called before the first frame update
    void Start()
    {
        hasEntered = false;

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerExit(Collider col)
    {
        if (col.CompareTag("Player"))
        {
            hasEntered = true;
        }
    }

    void OnTriggerEnter(Collider col)
    {
        if (hasEntered)
        {
            handheldMode = true;
            GameObject.Find("Main Camera").GetComponent<CameraShakeScript>().shake_long = true;
        }
    }
}
