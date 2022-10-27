using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemySpwan : MonoBehaviour
{
    public GameObject spawnedEnemy;
    // Start is called before the first frame update
    void Start()
    {
        Instantiate(spawnedEnemy);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
