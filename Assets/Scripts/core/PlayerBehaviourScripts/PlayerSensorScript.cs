using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Events;

public class PlayerSensorScript : MonoBehaviour
{
    [SerializeField] UnityEvent BeingAttacked;

    public static event Action BeingTeleported;
    public static event Action MonsterBoxTriggered;


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

        if (col.CompareTag("Energy"))
        {
            PlayerGlobalCondition._PlayerGlobalCondition.player_fuel = PlayerGlobalCondition._PlayerGlobalCondition.player_fuel + 10;
        }

        if (col.CompareTag("MonsterBoxTrigger"))
        {
            MonsterBoxTriggered?.Invoke();
        }
    }

}
