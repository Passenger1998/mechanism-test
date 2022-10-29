using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mapGenerator_2 : MonoBehaviour
{
    GameObject outcome_back, outcome_front;
    int index_back, index_front;
    public Transform pos_back, pos_front;

    //public GameObject outcome_back, outcome_front;

    mapArray mapArrayRef;

    bool mapGenDetect;

    void generateMap()
    {
        index_back = UnityEngine.Random.Range(0, mapArrayRef.mapList.Length);
        index_front = UnityEngine.Random.Range(0, mapArrayRef.mapList.Length);

        outcome_back = mapArrayRef.mapList[index_back];
        outcome_front = mapArrayRef.mapList[index_front];

        GameObject map_back = Instantiate(outcome_back, pos_back.position, Quaternion.Euler(new Vector3(-90, 0, 0)));
        GameObject map_front = Instantiate(outcome_front, pos_front.position, Quaternion.Euler(new Vector3(-90, 0, 0)));
    }

    void Awake()
    {
        mapArrayRef = GameObject.Find("mapArrayList").GetComponent<mapArray>();
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.CompareTag ("Player") && !mapGenDetect)
        {
            mapGenDetect = true;
            generateMap();
        }
    }
    void OnTriggerExit(Collider col)
    {
        if (col.CompareTag("Player"))
        {
            Destroy(gameObject);

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
