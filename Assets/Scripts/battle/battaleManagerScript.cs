using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class battaleManagerScript : MonoBehaviour
{

    static public battaleManagerScript Instance;

    /// <summary>
    ///  player status varaible sat area
    /// </summary>
    public int player_hp;
    public int player_fuel;
    public int player_bullet;

    /// <summary>
    /// enemy status varaible sat area
    /// </summary>
    public int enemy_hp;
    public int enemy_crystal;
    public GameObject crystal;

    private void OnEnable()
    {
        Instance = this;
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
