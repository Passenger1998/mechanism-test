using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mapStayDetection : MonoBehaviour
{

    public bool keepMap;
    public GameObject thisMap;

    void OnTriggerEnter(Collider col)
    {
        keepMap = true;
    }

    void OnTriggerStay(Collider col)
    {
        keepMap = true;
    }

    void onTriggerExit(Collider col)
    {
        keepMap = false;
    }

    // Start is called before the first frame update
    void Start()
    {
        keepMap = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (!keepMap)
        {
            Destroy(thisMap);
        }
    }
}
