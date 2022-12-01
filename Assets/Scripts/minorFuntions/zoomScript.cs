using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zoomScript : MonoBehaviour
{

    float manipulatePOV;
    bool shift;
    public float minPOV;
    public float maxPOV;
    public float zoomSpeed;

    // Start is called before the first frame update
    void Start()
    {
        shift = false;
        manipulatePOV = maxPOV;
    }

    // Update is called once per frame
    void Update()
    {
        Camera.main.fieldOfView = manipulatePOV;

        if (Input.GetKey("f") && !shift && manipulatePOV > minPOV)
        {
            manipulatePOV -= zoomSpeed * Time.deltaTime;
            
            if (manipulatePOV == minPOV)
            {
                shift = true;
            }
        } else if (manipulatePOV < maxPOV)
        {
            manipulatePOV += zoomSpeed * Time.deltaTime;
        }


    }
}
