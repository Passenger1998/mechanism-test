using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class explosionselfdetruct_script : MonoBehaviour
{
    // Start is called before the first frame update
    void Awake()
    {
        Destroy(gameObject, 2f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
