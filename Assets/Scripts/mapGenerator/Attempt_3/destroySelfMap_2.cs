using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroySelfMap_2 : MonoBehaviour
{
    public Transform player;
    public Transform thisMap;

    //void OnTriggerExit (Collider col)
    //{
    //    if (col.CompareTag("Player"))
    //    {
    //        Destroy (this.gameObject);
    //    }
    //}
    void Start()
    {

    }

    void Update()
    {

        if (Vector3.Distance(player.position, thisMap.position) <= 40)
        {
            Destroy(this.gameObject);
        }
        
    }

}
