using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGlobalCondition : MonoBehaviour
{


    public static PlayerGlobalCondition _PlayerGlobalCondition;
    public static event Action PlayerisDead;

    public int player_hp = 10;
    public int player_fuel = 10;
    public int player_bullet = 30;

    public float bullet_speed = 50.0f;

    public float player_speed = 0.1f;

    public float fuelLerpDuration = 5.0f;

    public int killcount = 0;

    //public bool userControlleable;

    public void OnEnable()
    {
        if (_PlayerGlobalCondition != null && _PlayerGlobalCondition != this)
        {
            Destroy(this);
        }
        else
        {
            _PlayerGlobalCondition = this;
        }


    }

    // Start is called before the first frame update


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(player_fuel <= 0)
        {
            player_fuel = 0;
        }

        if(player_speed <= 0)
        {
            player_speed = 0;
        }

        if(player_hp <= 0)
        {
            player_hp = 0;
            PlayerisDead?.Invoke();
        }
    }

    public void addhp()
    {
        if(player_fuel > 0)
        {
            if(Input.GetKeyDown(KeyCode.Q))
            {
                AudioClip rehealsound = AudioCentreScript._audioCentreScript.player_sound[4];
                AudioSource.PlayClipAtPoint(rehealsound, GameObject.FindGameObjectWithTag("MainCamera").transform.position, 10.0f);

                player_fuel -= 5;
                player_hp += 5;
            }
        }
    }


}
