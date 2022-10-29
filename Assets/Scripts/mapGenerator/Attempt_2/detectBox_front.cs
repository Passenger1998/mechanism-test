using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class detectBox_front : MonoBehaviour
{
    public GameObject frontbox;

    void OnTriggerEnter(Collider col)
    {
        if (col.CompareTag("Player") && frontbox.activeSelf)
        {
            frontbox.SetActive(false);
            return;
        } else if (col.CompareTag("Player") && !frontbox.activeSelf)
        {
            frontbox.SetActive(true);
            return;
        }
    }
    
// Start is called before the first frame update
    void Start()
    {
        frontbox.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
