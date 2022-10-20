using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hazard : MonoBehaviour
{

 void OnTriggerEnter(Collider col)
    {

        // do other jobs, then bullet destroys itself:
        if (col.gameObject.tag == "Player")
        {
            col.gameObject.GetComponent<Renderer> ().material.color = Color.red;
            Destroy (col.gameObject, 2f);

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
