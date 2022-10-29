using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroySelfMap : MonoBehaviour
{

    void OnTriggerExit (Collider col)
    {
        if (col.CompareTag("Player"))
        {
            Destroy (this.gameObject);
        }
    }
}
