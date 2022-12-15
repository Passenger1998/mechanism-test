using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletEffect_Gen3 : MonoBehaviour
{


    void OnTriggerEnter(Collider col)
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
        Destroy(gameObject, 5f);
    }

    // Update is called once per frame
    void Update()
    {
//set velocity to transform.foward
//set transform.roation to point in in specified direction
    }
}
