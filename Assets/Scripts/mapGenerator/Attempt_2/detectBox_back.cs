using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class detectBox_back : MonoBehaviour
{
    public GameObject backbox;

    void OnTriggerEnter(Collider col)
    {
        if (col.CompareTag("Player") && backbox.activeSelf)
        {
            backbox.SetActive(false);
            return;
        } else if (col.CompareTag("Player") && !backbox.activeSelf)
        {
            backbox.SetActive(true);
            return;
        }
    }
    
// Start is called before the first frame update
    void Start()
    {
        backbox.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
