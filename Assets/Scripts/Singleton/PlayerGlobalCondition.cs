using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGlobalCondition : MonoBehaviour
{


    public static PlayerGlobalCondition _PlayerGlobalCondition;

    public int player_hp = 10;
    public int player_fuel = 10;
    public int player_bullet = 30;

    public float bullet_speed = 100.0f;

    public float player_speed = 50.0f;

    public bool userControlleable;

    public void OnEnable()
    {
        if (_PlayerGlobalCondition != null && _PlayerGlobalCondition != this)
        {
            Destroy(this);
        }
        else
        {
            _PlayerGlobalCondition = this;
        }
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
