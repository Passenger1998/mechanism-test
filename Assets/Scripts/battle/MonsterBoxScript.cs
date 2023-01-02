using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterBoxScript : MonoBehaviour
{

    public GameObject monster;
    public Transform [] monsterSpawnPoint;
    public float waitingtime = 1.0f;

    private void OnEnable()
    {
        //PlayerSensorScript.MonsterBoxTriggered += MonsterSpawn;
  
    } 

    private void OnDisable()
    {
        //PlayerSensorScript.MonsterBoxTriggered -= MonsterSpawn;
    }

    void MonsterSpawn()
    {   

        for (int i=0; i < monsterSpawnPoint.Length; i++)
        {
            
            Instantiate (monster, monsterSpawnPoint[i].position, Quaternion.identity);

        }
        
    }

    private void OnTriggerEnter(Collider col)
    {
        if(col.CompareTag("Player"))
        {
            MonsterSpawn();
            Destroy(this.gameObject);
        }
    }


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
