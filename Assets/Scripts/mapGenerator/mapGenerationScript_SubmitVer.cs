using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mapGenerationScript_SubmitVer : MonoBehaviour
{

    public Transform pos_front;

    public GameObject mapArraythisscene;

    public GameObject backblock;

    public bool mapGenDetect;

    int index_back;

    mapArrary_submitver mapArrary_submitver;

    // Start is called before the first frame update
    private void Awake()
    {
        mapArrary_submitver = mapArraythisscene.GetComponent<mapArrary_submitver>();
        //this disable this whole script:
        mapGenDetect = true;

        backblock.gameObject.GetComponent<BoxCollider>().enabled = false;
    }

    private void OnTriggerEnter(Collider enter)
    {
        if (enter.CompareTag("Player"))
        {
            Debug.Log("inzone");
            backblock.gameObject.GetComponent<BoxCollider>().enabled = true;
        }
    }

    void OnTriggerExit(Collider exit)
    {
        if (exit.CompareTag("Player") && !mapGenDetect)
        {
            Debug.Log("outzone");
            mapGenDetect = true;

            index_back = UnityEngine.Random.Range(0, mapArrary_submitver.blockPrefabArray.Length);

            GameObject random_pick_block = mapArrary_submitver.blockPrefabArray[index_back];

            GameObject newBlock = Instantiate(random_pick_block, pos_front.position, Quaternion.Euler(new Vector3(-90, 0, 0)));

            mapGenDetect = false;
            //Debug.Log("front block is generated and next block would be block number " + orderOfBlock);

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
