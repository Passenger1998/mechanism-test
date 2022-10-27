using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mapGenerator : MonoBehaviour
{
    //this is where prefab maps is added
    public GameObject[] prefabMaps;
    public GameObject player, trigger_back, trigger_front;

    bool whetherOnMap;

    BoxCollider onMap;

    void onTriggerEnter(Collider onMap)
    {
        whetherOnMap = true;
    }

   
    void activateMapGenerator()
    {
        
    }

    // Start is called before the first frame update
    void Start()
    {
        onMap = GetComponent<BoxCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
