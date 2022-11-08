using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mapGenerateForward_4 : MonoBehaviour
{

    public Transform pos_front;

    mapArrayOneWay mapArrayRef;

    public bool mapGenDetect;

    int orderOfBlock;

    void Awake()
    {
        mapArrayRef = GameObject.Find("mapArrayList").GetComponent<mapArrayOneWay>();
    }
    void OnTriggerEnter(Collider col)
    {
        if (col.CompareTag("Player") && !mapGenDetect)
        {
            mapGenDetect = true;

            GameObject newBlock = Instantiate(mapArrayRef.blockPrefabArray[orderOfBlock], pos_front.position, Quaternion.Euler(new Vector3(-90, 0, 0)));

            mapArrayOneWay.Instance.orderOfBlock ++;

            Debug.Log("front block is generated and next block would be block number " + orderOfBlock);

        }
    }

    // Start is called before the first frame update
    void Start()
    {
        mapGenDetect = false;
        orderOfBlock = mapArrayOneWay.Instance.orderOfBlock;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
