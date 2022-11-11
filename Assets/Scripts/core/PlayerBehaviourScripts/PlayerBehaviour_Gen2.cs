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

    public Transform cannon;
    public float cannonSpeed;
    float cannonAngle;

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
        if (Input.GetKeyDown("space"))
        {
            shoot = true;
        }

        if (shoot)
        {
            Shoot ();
            shoot = false;
        }

        //cannon aim and shoot

        //RotateCannon();

        //target = transform.Find("Main Camera").GetComponent<Camera>().ScreenToWorldPoint(new Vector3 (Input.mousePosition.x,Input.mousePosition.y, transform.position.z));
        //mouse_position.transform.position = new Vector2(target.x, target.y);
        //cannonRotateCentre.transform.LookAt(mouse_position.transform.position);

        //cannonRotateCentre.transform.LookAt(Input.mousePosition);

    }

    //void RotateCannon()
    //{
    //    cannonAngle += Input.GetAxis("Mouse Y") * cannonSpeed * -Time.deltaTime;
    //    cannonAngle = Mathf.Clamp(cannonAngle, 90, 180);
    //    cannon.localRotation = Quaternion.AngleAxis(cannonAngle, Vector3.back);
    //}

    void FixedUpdate()
    {
        //movement control
        rb.velocity = new Vector3 (inputX * speed, inputY * speed, 0);

    }

    void Shoot()
    {
        GameObject bulletSpawn = Instantiate (bullet, bulletPos.position, Quaternion.identity);
        bulletSpawn.GetComponent<Rigidbody> ().velocity = new Vector3 (bulletspeed, 0, 0);
    }

}
