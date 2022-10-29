using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class determineMapGenDirection : MonoBehaviour
{

    float inputX;

    public GameObject backtrigger, fronttrigger;

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

        if (inputX < 0)
        {
            backtrigger.SetActive(true);
            fronttrigger.SetActive(false);
        } else if (inputX > 0)
        {
            fronttrigger.SetActive(true);
            backtrigger.SetActive(false);
        }
    }
}
