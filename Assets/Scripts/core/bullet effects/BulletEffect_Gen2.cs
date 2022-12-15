using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletEffect_Gen2 : MonoBehaviour
{


    void OnCollisionEnter(Collision col)
    {

        IEnumerator ChangeColor()
        {

            col.gameObject.GetComponent<Renderer>().material.color = Color.red;

            yield return new WaitForSeconds(2);//2 seconds for example

            col.gameObject.GetComponent<Renderer>().material.color = Color.blue;

        }

        // do other jobs, then bullet destroys itself:
        if (col.gameObject.tag == "Destroyable Obstacle")
        {

            Destroy (col.gameObject, 2f);

        } else if (col.gameObject.tag == "Unreakble Obstacle")
        {

            Destroy(gameObject);

        } else if (col.gameObject.tag == "Enemy")
        {

            //ChangeColor();

            Destroy(gameObject);


        } else
        {
            Destroy(gameObject, 3f);
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
//set velocity to transform.foward
//set transform.roation to point in in specified direction
    }
}
