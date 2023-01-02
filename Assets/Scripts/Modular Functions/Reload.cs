using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reload : MonoBehaviour
{
    
    //attach reload sucess and unsurcess audio file here

    public void _Reload()
    {
        Debug.Log("reload");

        if (PlayerGlobalCondition._PlayerGlobalCondition.player_fuel > 0)
        {
            //play sucess sound

            PlayerGlobalCondition._PlayerGlobalCondition.player_bullet = PlayerGlobalCondition._PlayerGlobalCondition.player_bullet + 10;
            PlayerGlobalCondition._PlayerGlobalCondition.player_fuel = PlayerGlobalCondition._PlayerGlobalCondition.player_fuel - 5;
        } else
        {
            //play fail sound
        }
    }

}
