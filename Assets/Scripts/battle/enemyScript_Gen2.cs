using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Claims;
using UnityEngine;

public class enemyScript_Gen2 : MonoBehaviour
{

    public int enemy_hp = 10;
    public GameObject energyclust;
    bool enemystayinlivearea = true;

    void OnTriggerEnter(Collider col)
    {

        if (col.gameObject.tag == "Bullet")
        {
            AudioClip monster_hurt = AudioCentreScript._audioCentreScript.monster_sound[0];
            AudioSource.PlayClipAtPoint(monster_hurt, this.gameObject.transform.position, 100.0f);

            enemy_hp = enemy_hp - 1;
            //Debug.Log(this.gameObject + " hp is now " + enemy_hp);

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
            AudioClip monster_deathscream = AudioCentreScript._audioCentreScript.monster_sound[1];
            AudioSource.PlayClipAtPoint(monster_deathscream, this.gameObject.transform.position, 100.0f);

            Instantiate(energyclust, this.gameObject.transform.position, Quaternion.identity);
            Destroy(this.gameObject);
            PlayerGlobalCondition._PlayerGlobalCondition.killcount += 1;
            PlayerGlobalCondition._PlayerGlobalCondition.player_fuel += 5;

        }
    }


}

