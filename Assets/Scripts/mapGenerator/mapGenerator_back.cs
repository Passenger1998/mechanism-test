using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mapGenerator_back : MonoBehaviour
{
    GameObject outcomeMap;
    int index;

    void pickRandomMap()
    {
        index = Random.Range(0, mapList.Length);
        outcomeMap = mapList[index];
    }

    void addMapp()
    {
        transform thisLocation = transform.position;
    }

    void onCollisionEnger(Collision col)
    {
        if (col.gameObject.tag == "Player")
        {
           

         }
    }

     void Start()
    {

    }

     void Update()
    {

    }
}
