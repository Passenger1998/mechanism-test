using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Events;

public class PlayerSensorScript : MonoBehaviour
{
    [SerializeField] UnityEvent BeingAttacked;

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

            AllSceneManager._AllSceneManager.isTeleporting_ = true;

            //Debug.Log("teleport");
        }

        if (col.CompareTag("Enemy"))
        {
            BeingAttacked.Invoke();
            Debug.Log("attacked");

        }
    }

}
