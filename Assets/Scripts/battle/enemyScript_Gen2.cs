using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Claims;
using UnityEngine;

public class enemyScript_Gen2 : MonoBehaviour
{

    public int enemy_hp = 10;

    void OnTriggerEnter(Collider col)
    {

        if (col.gameObject.tag == "Bullet")
        {

            enemy_hp = enemy_hp - 1;
            Debug.Log(this.gameObject + " hp is now " + enemy_hp);

            //StartCoroutine(colourShift(hitColorChangeDuration));


        }
    }

    void Start()
    {
        

    }

    // Update is called once per frame
    void Update()
    {
        if (enemy_hp == 0)
        {

            Destroy(this.gameObject);
            PlayerGlobalCondition._PlayerGlobalCondition.player_fuel = PlayerGlobalCondition._PlayerGlobalCondition.player_fuel + 10;

        }
    }


}

