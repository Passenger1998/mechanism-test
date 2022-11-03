using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerBattleSystem : MonoBehaviour
{
    public int player_hp;
    int fuel;
    int bullet;

    void OnCollisionEnter(Collision col)
    {

        // do other jobs, then bullet destroys itself:
        if (col.gameObject.tag == "Enemy")
        {

            player_hp = player_hp - 1;
            Debug.Log(player_hp);

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
