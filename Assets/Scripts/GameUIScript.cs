using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameUIScript : MonoBehaviour
{

    int health;
    public GameObject _health;

    int energy_level;
    public GameObject _energy_level;

    public GameObject player;



    // Start is called before the first frame update
    void Start()
    {
        //health = battaleManagerScript.Instance.player_hp;
        health = player.gameObject.GetComponent<playerBattleSystem>().player_hp;
        Debug.Log("UI hp is " + health);
    }

    // Update is called once per frame
    void Update()
    {
        health = player.gameObject.GetComponent<playerBattleSystem>().player_hp;
        _health.gameObject.GetComponent<Text>().text = "HEALTH: " + health;

        _energy_level.gameObject.GetComponent<Text>().text = "ENERGY_LEVEL: " + energy_level;
    }

    public void EnergyCollectionCount()
    {
        energy_level++;
    }

}
