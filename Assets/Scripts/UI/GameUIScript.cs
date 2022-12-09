using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameUIScript : MonoBehaviour
{
    public int maxHealth;
    public int health;
    public GameObject _health;
    //public GameObject slider;


    public int energy_level;
    public GameObject _energy_level;

    public GameObject player;
    public GameObject interaction_manager;


    int bullet_count;
    public GameObject _bullet_count;



    // Start is called before the first frame update

    //void Awake()
    //{
    //    //health = battaleManagerScript.Instance.player_hp;
    //    health = player.gameObject.GetComponent<playerBattleSystem>().player_hp;
    //    //Debug.Log("UI hp is " + health);
    //    maxHealth = player.gameObject.GetComponent<playerBattleSystem>().player_hp;
    //}

    void Start()
    {
        //health = battaleManagerScript.Instance.player_hp;
        //health = player.gameObject.GetComponent<playerBattleSystem>().player_hp;
        //Debug.Log("UI hp is " + health);
        maxHealth = interaction_manager.gameObject.GetComponent < battaleManagerScript>().player_hp;

    }

    // Update is called once per frame
    void Update()
    {
        health = player.gameObject.GetComponent<playerBattleSystem>().player_hp;
        //_health.gameObject.GetComponent<Text>().text = "HEALTH: " + health;
        _health.gameObject.GetComponent<Text>().text = "" + health;

        //float fillValue = slider.gameObject.GetComponent<Slider>().value = health / maxHealth;

        
        //slider.gameObject.GetComponent<Slider>().value = fillValue;
        
        

        //_energy_level.gameObject.GetComponent<Text>().text = "ENERGY_LEVEL: " + energy_level;
        _energy_level.gameObject.GetComponent<Text>().text = "" + energy_level;

        bullet_count = player.gameObject.GetComponent<PlayerBehaviour_Gen2>().player_bullet;
        //_bullet_count.gameObject.GetComponent<Text>().text = "AMMO: " + bullet_count;
        _bullet_count.gameObject.GetComponent<Text>().text = "" + bullet_count;
    }

    public void EnergyCollectionCount()
    {
        energy_level++;
    }

    public void EnergyUsedforReload()
    {
        energy_level--;
    }
}
