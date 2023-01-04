using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reload : MonoBehaviour
{
    
    //attach reload sucess and unsurcess audio file here

    public void _Reload()
    {
        //Debug.Log("reload");

        if (PlayerGlobalCondition._PlayerGlobalCondition.player_fuel > 0)
        {
            //play sucess sound
            AudioClip reloadsound = AudioCentreScript._audioCentreScript.player_sound[3];
            AudioSource.PlayClipAtPoint(reloadsound, GameObject.FindGameObjectWithTag("MainCamera").transform.position, 100.0f);


            PlayerGlobalCondition._PlayerGlobalCondition.player_bullet = PlayerGlobalCondition._PlayerGlobalCondition.player_bullet + 10;
            PlayerGlobalCondition._PlayerGlobalCondition.player_fuel = PlayerGlobalCondition._PlayerGlobalCondition.player_fuel - 5;
        } else
        {
            //play fail sound
        }
    }

}
