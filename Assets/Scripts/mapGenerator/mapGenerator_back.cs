using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mapGenerator_back : MonoBehaviour
{
    GameObject outcomeMap;
    GameObject [] mapList;
    int index;
    public Transform mapLoadPos;

    void Awake()
    {
        mapList = GameObject.Find("mapArrary").GetComponent<mapArray>().mapList;
    }

    void onCollisionEnger(Collision col)
    {
        if (col.gameObject.tag == "Player")
        {

            Instantiate(outcomeMap, mapLoadPos.position, mapLoadPos.rotation);

        }
    }

     void Start()
    {
        //randomly pick up a map from list
        index = Random.Range (0, mapList.Length);
        outcomeMap = mapList[index];



    }

     void Update()
    {

    }
}
