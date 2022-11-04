using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerBattleSystem : MonoBehaviour
{
    int player_hp;

    void OnCollisionEnter(Collision col)
    {

        if (col.gameObject.tag == "Enemy")
        {
            
            player_hp = player_hp - 1;
            Debug.Log(player_hp);

        }
    }

    void Start ()
    {
        player_hp = battaleManagerScript.Instance.player_hp;
        Debug.Log("player starting hp is " + player_hp);
    }




    void Update()
    {
        if (player_hp <= 0)
        {
            ///play die animation here, animation duration last seconds can be written below///
            Debug.Log("deleting!!! hp"+ player_hp);
            Destroy(this.gameObject, 2f);
           
        }
    }
}
