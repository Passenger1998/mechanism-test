using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mapGenerator_back : MonoBehaviour
{
    GameObject outcomeMap;
    int index;
    public Transform mapLoadPos_back;
    bool mapLoadDetect;
    mapArray mapArrayRef;
    

    void Awake()
    {
        mapArrayRef  = GameObject.Find("mapArrayList").GetComponent<mapArray>();
        //mapArrayRef.mapList;
        //mapList = GameObject.Find("mapArrary").GetComponent<mapArray>().mapList;
        //_myMapArrayRef.mapList;
        //UnityEngine.Random.Range()
    }

    void generateMap()
    {
        index = UnityEngine.Random.Range(0, mapArrayRef.mapList.Length);
        outcomeMap = mapArrayRef.mapList[index];

        GameObject mapGenerated = Instantiate(outcomeMap, mapLoadPos_back.position, Quaternion.identity);
    }

    void onTriggerEnter(Collider col)
    {
        if (col.CompareTag ("Player") && mapLoadDetect == false)
        {

            generateMap();

            mapLoadDetect = true;

            return;

        }
    }

    void onTriggerStay(Collider col)
    {
        if (col.CompareTag("Player") && mapLoadDetect == false)
        {

            generateMap();

            mapLoadDetect = true;

            return;

        }
    }

    /// <summary>
    /// 
    /// </summary>

    void Start()
    {
        mapLoadDetect = false;
    }

     void Update()
    {
  
    }
}
