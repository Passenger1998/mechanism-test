using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mapGenerator_back_3 : MonoBehaviour
{
    GameObject outcome_back;
    int index_back;
    public Transform pos_back;

    mapArray_2 mapArrayRef;

    bool mapGenDetect;

    void generateMap_back()
    {
        index_back = UnityEngine.Random.Range(0, mapArrayRef.mapList.Length);

        outcome_back = mapArrayRef.mapList[index_back];

        GameObject map_back = Instantiate(outcome_back, pos_back.position, Quaternion.Euler(new Vector3(-90, 0, 0)));
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
            Debug.Log("back map is generated");
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
