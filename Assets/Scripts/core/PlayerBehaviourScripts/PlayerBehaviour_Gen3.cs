using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerBehaviour_Gen3 : MonoBehaviour
{
    [SerializeField] private UnityEvent PlayerReload;
    [SerializeField] private UnityEvent PlayerShoot;

    Rigidbody rb;

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

        //shoot bullet & bullet count
        if (Input.GetMouseButtonDown(0) && PlayerGlobalCondition._PlayerGlobalCondition.player_bullet > 0)
        {
            shoot = true;
        }

        if (shoot)
        {
            PlayerShoot.Invoke ();
            shoot = false;
        }


        //Player Reload
        if (Input.GetKeyDown(KeyCode.R))
        {
            PlayerReload.Invoke();
        }

        if  (AllSceneManager._AllSceneManager.isTeleporting_)
        {
            StopMoving();
        }
    }

    void Moving()
    {
        if (PlayerGlobalCondition._PlayerGlobalCondition.userControlleable)
        {
            inputX = Input.GetAxis("Horizontal");
            inputY = Input.GetAxis("Vertical");
        }
        
    }

    void FixedUpdate()
    {
        //movement control
        rb.velocity = new Vector3 (inputX * PlayerGlobalCondition._PlayerGlobalCondition.player_speed, inputY * PlayerGlobalCondition._PlayerGlobalCondition.player_speed, 0);

    }

    //void Shoot()
    //{
    //    GameObject bulletSpawn = Instantiate (bullet, bulletPos.position, Quaternion.LookRotation(bulletPos.transform.right,Vector3.up));
    //    //bulletSpawn.GetComponent<Rigidbody> ().velocity = new Vector3 (bulletspeed, 0, 0);
    //    bulletSpawn.GetComponent<Rigidbody>().velocity = new Vector2 (bulletPos.transform.right.x * PlayerGlobalCondition._PlayerGlobalCondition.bullet_speed, bulletPos.transform.right.y * PlayerGlobalCondition._PlayerGlobalCondition.bullet_speed);
    //}



    void StopMoving()
    {
        PlayerGlobalCondition._PlayerGlobalCondition.player_speed = 0.0f;
    }

}
