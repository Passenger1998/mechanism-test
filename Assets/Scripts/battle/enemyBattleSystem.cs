using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyBattleSystem : MonoBehaviour
{
    int enemy_hp;
    int enemy_crystal;
    GameObject crystal;

    void OnCollisionEnter(Collision col)
    {

        if (col.gameObject.tag == "Bullet")
        {

            enemy_hp = enemy_hp - 1;
            Debug.Log(this.gameObject + " hp is now " + enemy_hp);

        }
    }

    void Start()
    {
        enemy_hp = battaleManagerScript.Instance.enemy_hp;
        Debug.Log(this.gameObject + " starting hp is " + enemy_hp);


        crystal = battaleManagerScript.Instance.crystal;
        Debug.Log(this.gameObject + " crystal is on load");

        enemy_crystal = battaleManagerScript.Instance.enemy_crystal;
        Debug.Log(this.gameObject + " starting crystal is " + enemy_crystal);

    }

    // Update is called once per frame
    void Update()
    {
        if (enemy_hp <= 0)
        {
            ///play die animation here, animation duration last seconds can be written below///
            Debug.Log("deleting!!! hp" + enemy_hp);
            
            for (int i = 0; i < enemy_crystal; i++)
            {
                GameObject crystal_explode = Instantiate(crystal, this.gameObject.transform.position, Quaternion.identity);
                
            }
            
            Destroy(this.gameObject, 2f);

        }
    }
}

