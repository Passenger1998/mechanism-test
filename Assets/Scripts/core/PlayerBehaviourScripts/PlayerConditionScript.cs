using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerConditionScript : MonoBehaviour
{

    public static event Action BeingTeleported;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider col)
    {
        if(col.CompareTag("Teleport"))
        {
            BeingTeleported?.Invoke();
            Debug.Log("teleport");
        }
    }

}
