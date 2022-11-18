using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameUIScript : MonoBehaviour
{

    public int health;
    public GameObject _status;
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        //health = battaleManagerScript.Instance.player_hp;
        health = player.gameObject.GetComponent<playerBattleSystem>().player_hp;
    }

    // Update is called once per frame
    void Update()
    {
        _status.gameObject.GetComponent<Text>().text = "HEALTH: " + health;
    }
}
