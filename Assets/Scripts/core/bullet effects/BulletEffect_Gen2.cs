using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletEffect_Gen2 : MonoBehaviour
{

    void OnCollisionEnter(Collision col)
    {

        // do other jobs, then bullet destroys itself:
        if (col.gameObject.tag == "Destroyable Obstacle")
        {

            Destroy (col.gameObject, 2f);

        } else if (col.gameObject.tag == "Unbreakble Obstacle")
        {

            Destroy(gameObject);

        } else if (col.gameObject.tag == "Enemy")
        {
            col.gameObject.GetComponent<Renderer>().material.color = Color.red;
            Destroy(this.gameObject);
        } else
        {
            Destroy(this.gameObject, 5f);
        }



        ///
        /// instant kill///
        /// 


    }

    //void OnTriggerEnger(Collision col)
    //{
    //    if (col.gameObject.tag == "Enemy")
    //    {
    //        col.gameObject.GetComponent<Renderer>().material.color = Color.red;
    //        Destroy(col.gameObject, 2f);
    //    }

    //    //Destroy(gameObject);
    //}

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
}
