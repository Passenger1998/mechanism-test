using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mapGenerator_front_3 : MonoBehaviour
{
    GameObject outcome_front;
    int index_front;
    public Transform pos_front;

    mapArray_2 mapArrayRef;

    bool mapGenDetect;

    void generateMap_back()
    {
        index_front = UnityEngine.Random.Range(0, mapArrayRef.mapList.Length);

        outcome_front = mapArrayRef.mapList[index_front];

        GameObject map_front = Instantiate(outcome_front, pos_front.position, Quaternion.Euler(new Vector3(-90, 0, 0)));
    }

    void Awake()
    {
        mapArrayRef = GameObject.Find("mapArrayList").GetComponent<mapArray_2>();
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.CompareTag("Player") && !mapGenDetect)
        {
            mapGenDetect = true;
            generateMap_back();
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        mapGenDetect = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
