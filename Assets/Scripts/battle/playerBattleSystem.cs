using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerBattleSystem : MonoBehaviour
{
    public int player_hp;
    public int max_hp;

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
        max_hp = battaleManagerScript.Instance.player_hp;
        //Debug.Log("player starting hp is " + player_hp);
    }




    void Update()
    {


        if (player_hp <= 0)
        {
            ///play die animation here, animation duration last seconds can be written below///
            //Debug.Log("u r dying");
            Destroy(this.gameObject, 2f);
           
        }
    }
}
