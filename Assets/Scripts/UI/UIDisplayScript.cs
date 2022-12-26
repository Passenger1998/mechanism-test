using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIDisplayScript : MonoBehaviour
{

    public GameObject player_hp;

    public GameObject fuel_level;

    public GameObject bullet_count;


    void FixedUpdate()
    {
        player_hp.gameObject.GetComponent<Text>().text = "" + PlayerGlobalCondition._PlayerGlobalCondition.player_hp;

        fuel_level.gameObject.GetComponent<Text>().text = "" + PlayerGlobalCondition._PlayerGlobalCondition.player_fuel;

        bullet_count.gameObject.GetComponent<Text>().text = "" + PlayerGlobalCondition._PlayerGlobalCondition.player_bullet;
    }
}
