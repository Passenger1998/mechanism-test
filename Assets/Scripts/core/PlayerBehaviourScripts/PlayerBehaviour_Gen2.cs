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

    public int player_bullet;

    public int energy_level;
    GameUIScript energyAttributor; 


    void Awake()
    {

        rb = GetComponent<Rigidbody> ();

    }


    // Start is called before the first frame update
    void Start()
    {
        player_bullet = battaleManagerScript.Instance.player_bullet;

        energyAttributor = GameObject.Find("UI").GetComponent<GameUIScript>();
    }

    // Update is called once per frame
    void Update()
    {
        
        inputX = Input.GetAxis("Horizontal");
        inputY = Input.GetAxis ("Vertical");

        //shoot bullet & bullet count
        if (Input.GetMouseButtonDown(0) && player_bullet > 0)
        {
            shoot = true;
        }

        if (shoot)
        {
            Shoot ();
            shoot = false;
            player_bullet--;
        }

        //load energy_level count from UI
        energy_level = GameObject.FindGameObjectWithTag("UI").GetComponent<GameUIScript>().energy_level;

        AmmoReload();
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

    void AmmoReload()
    {
        if (Input.GetKeyDown("space") && energy_level > 0)
        {
            player_bullet = player_bullet +10;
            energyAttributor.EnergyUsedforReload();
        }
    }

}
