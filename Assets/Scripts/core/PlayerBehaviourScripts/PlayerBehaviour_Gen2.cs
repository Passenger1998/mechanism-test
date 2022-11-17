using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour_Gen2 : MonoBehaviour
{
    Rigidbody rb;

    public float speed;
    public float bulletspeed;

    public GameObject bullet;
    public Transform bulletPos;

    float inputX, inputY;
    
    bool shoot = false;


    void Awake()
    {

        rb = GetComponent<Rigidbody> ();

    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        inputX = Input.GetAxis("Horizontal");
        inputY = Input.GetAxis ("Vertical");

        //shoot bullet
        if (Input.GetMouseButtonDown(0))
        {
            shoot = true;
        }

        if (shoot)
        {
            Shoot ();
            shoot = false;
        }

    }

    void FixedUpdate()
    {
        //movement control
        rb.velocity = new Vector3 (inputX * speed, inputY * speed, 0);

    }

    void Shoot()
    {
        GameObject bulletSpawn = Instantiate (bullet, bulletPos.position, Quaternion.LookRotation(bulletPos.transform.right,Vector3.up));
        //bulletSpawn.GetComponent<Rigidbody> ().velocity = new Vector3 (bulletspeed, 0, 0);
        bulletSpawn.GetComponent<Rigidbody>().velocity = new Vector2 (bulletPos.transform.right.x * bulletspeed, bulletPos.transform.right.y * bulletspeed);
    }

}
