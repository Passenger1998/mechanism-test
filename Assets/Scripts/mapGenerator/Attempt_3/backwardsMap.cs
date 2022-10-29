using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class backwardsMap : MonoBehaviour
{
    GameObject outcome_back;
    int index_back;
    public Transform pos_back;

    mapManagerScript_Front mapArrayRef;

    bool mapGenDetect;

    void generateMap_back()
    {
        index_back = UnityEngine.Random.Range(0, mapArrayRef.mapPrefab.Length);

        outcome_back = mapArrayRef.mapPrefab[index_back];

        GameObject map_back = Instantiate(outcome_back, pos_back.position, Quaternion.Euler(new Vector3(-90, 0, 0)));
    }

    void Awake()
    {
        mapArrayRef = GameObject.Find("mapManager").GetComponent<mapManagerScript_Front>();
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
