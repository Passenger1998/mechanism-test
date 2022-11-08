using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class determineMapGenDirection : MonoBehaviour
{

    float inputX;

    public GameObject backtrigger, fronttrigger;

    bool isShiponMap;

    void OnTriggerStay (Collider col)
    {
        if (col.CompareTag("Player"))
        {
            isShiponMap = true;
        }
    }

    void OnTriggerExit(Collider col)
    {
        if (col.CompareTag("Player"))
        {
            isShiponMap = false;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        backtrigger.SetActive(false);
        fronttrigger.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        inputX = Input.GetAxis("Horizontal");

        if (inputX < 0 && isShiponMap == true)
        {
            backtrigger.SetActive(true);
            fronttrigger.SetActive(false);
        } else if (inputX > 0 && isShiponMap == true)
        {
            fronttrigger.SetActive(true);
            backtrigger.SetActive(false);
        }
    }
}
