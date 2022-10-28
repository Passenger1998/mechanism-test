using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mapGenerator_front : MonoBehaviour
{
    GameObject outcomeMap;
    int index;
    public Transform mapLoadPos_front;
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

        GameObject mapGenerated = Instantiate(outcomeMap, mapLoadPos_front.position, Quaternion.identity);
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
    void OnTriggerExit(Collider other)
    {
        //destroy map
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
