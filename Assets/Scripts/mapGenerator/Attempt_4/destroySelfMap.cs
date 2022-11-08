using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroySelfMap : MonoBehaviour
{

    void OnTriggerExit (Collider col)
    {
        if (col.CompareTag("Player"))
        {
            Debug.Log("destroying this!");
            Destroy (this.gameObject);
            
        }
    }
}
