using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class crystalExplodeScript : MonoBehaviour
{
    Rigidbody rb;
    Vector3 crystal_explode_velocity;
    

    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();

        crystal_explode_velocity = battaleManagerScript.Instance.crystal_explode_velocity;
        Debug.Log(this.gameObject + " set velocity to" + crystal_explode_velocity);

        rb.velocity = crystal_explode_velocity;


    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
