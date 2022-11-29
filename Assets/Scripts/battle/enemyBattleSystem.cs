using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Claims;
using UnityEngine;

public class enemyBattleSystem : MonoBehaviour
{
    int enemy_hp;
    int enemy_crystal;
    GameObject crystal;
    public bool enemy_is_dead;

    GameUIScript energyAttributor;

    float crystal_velocity;

    //Rigidbody rb;

    public float duration;

    //to allow change shift colour back and for: hit effect fill in here
    private IEnumerator colourShift (float duration)
    {
        var originalColour = this.gameObject.GetComponent<Renderer>().material.color;
        this.gameObject.GetComponent<Renderer>().material.color = Color.red;
        yield return new WaitForSeconds(duration);
        this.gameObject.GetComponent<Renderer>().material.color = originalColour;
    }

    void OnCollisionEnter(Collision col)
    {

        if (col.gameObject.tag == "Bullet")
        {

            enemy_hp = enemy_hp - 1;
            //Debug.Log(this.gameObject + " hp is now " + enemy_hp);

            StartCoroutine(colourShift(duration));


        }
    }

    void Start()
    {
        enemy_hp = battaleManagerScript.Instance.enemy_hp;
        //Debug.Log(this.gameObject + " starting hp is " + enemy_hp);


        //crystal = battaleManagerScript.Instance.crystal;
        //Debug.Log(this.gameObject + " crystal is on load");

        //enemy_crystal = battaleManagerScript.Instance.enemy_crystal;
        //Debug.Log(this.gameObject + " starting crystal is " + enemy_crystal);

       // rb = crystal.GetComponent<Rigidbody>();

        //crystal_velocity = battaleManagerScript.Instance.crystal_velocity;
        //Debug.Log(this.gameObject + " set velocity to" + crystal_velocity);

        ///connect to UI display///
        energyAttributor = GameObject.Find("UI").GetComponent<GameUIScript>();

    }

    // Update is called once per frame
    void Update()
    {
        if (enemy_hp == 0)
        {
            ///play die animation here, animation duration last seconds can be written below///

            //Debug.Log("deleting!!! hp" + enemy_hp);

            //for (int i = 0; i <= enemy_crystal; i++)
            //{
            //    //GameObject crystal_explode = Instantiate(crystal, this.gameObject.transform.position, Quaternion.Euler(UnityEngine.Random.Range(0f, 360f), UnityEngine.Random.Range(0f, 360f), UnityEngine.Random.Range(0f, 360f)));
            //    //crystal_explode.transform.Translate(Vector3.forward * crystal_velocity * Time.deltaTime);

            //    GameObject explodedCrystal = Instantiate(crystal, this.gameObject.transform.position, Quaternion.identity);

            //    explodedCrystal.transform.position = Vector3.Lerp(explodedCrystal.transform.position, GameObject.FindGameObjectWithTag("Player").transform.position, 0.001f);

            //    //Vector3 Movement = new Vector3(UnityEngine.Random.Range(-1, 1), UnityEngine.Random.Range(-1, 1), transform.position.z);

            //    //Rigidbody rb = explodedCrystal.GetComponent<Rigidbody>();

            //    //rb.AddForce(Movement * crystal_velocity);
            //}

            energyAttributor.EnergyCollectionCount();

            Destroy(this.gameObject);

        }
    }


}

