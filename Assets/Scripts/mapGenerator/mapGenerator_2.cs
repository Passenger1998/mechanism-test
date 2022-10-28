using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mapGenerator_2 : MonoBehaviour
{
    GameObject outcome_back, outcome_front;
    int index_back, index_front;
    public Transform pos_back, pos_front;

    mapArray mapArrayRef;

    void generateMap()
    {
        index_back = UnityEngine.Random.Range(0, mapArrayRef.mapList.Length);
        index_front = UnityEngine.Random.Range(0, mapArrayRef.mapList.Length);

        outcome_back = mapArrayRef.mapList[index_back];
        outcome_front = mapArrayRef.mapList[index_front];

        GameObject map_back = Instantiate(outcome_back, pos_back.position, Quaternion.identity);
        GameObject map_front = Instantiate(outcome_front, pos_front.position, Quaternion.identity);
    }

    void Awake()
    {
        mapArrayRef = GameObject.Find("mapArrayList").GetComponent<mapArray>();
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.CompareTag ("Player"))
        {
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
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
