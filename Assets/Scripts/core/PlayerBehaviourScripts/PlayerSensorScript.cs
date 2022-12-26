using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerSensorScript : MonoBehaviour
{

    public static event Action BeingTeleported;
    public static event Action BeingAttacked;


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

        if (col.CompareTag("Enemy"))
        {
            BeingAttacked?.Invoke();
            Debug.Log("teleport");
        }
    }

}
