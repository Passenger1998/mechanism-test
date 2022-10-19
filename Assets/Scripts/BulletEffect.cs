using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletEffect : MonoBehaviour
{

    void OnCollisionEnter(Collision col)
    {

        // do other jobs, then bullet destroys itself:
        if (col.gameObject.tag == "Destroyable Obstacle")
        {

            Destroy (col.gameObject, 2f);

        }

         if (col.gameObject.tag == "Unbreakble Obstacle")
        {

            Destroy(gameObject);

        }

        //Destroy(gameObject);

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
