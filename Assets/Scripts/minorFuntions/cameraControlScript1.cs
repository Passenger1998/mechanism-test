using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class cameraControlScript1 : MonoBehaviour
{
    public float rotateInSpeed;
    public float rotateOutSpeed;
    public Transform playerPos;
    public Transform planeView;

    float manipulatePOV;
    public float minPOV;
    public float maxPOV;
    public float zoomInSpeed;
    public float zoomOutSpeed;

    bool shift;
    //bool shift_;

    void Start()
    {
        shift = false;
        manipulatePOV = maxPOV;
    }

    void Update()
    {

        Camera.main.fieldOfView = manipulatePOV;

        //while (Input.GetKey("f") && !shift_ && manipulatePOV > minPOV)
        //{
        //    manipulatePOV -= zoomInSpeed * Time.deltaTime;
        //}

        //if (manipulatePOV == minPOV)
        //{
        //    shift_ = true;
        //}


        if (Input.GetKey("f") && !shift)
        {
            Quaternion rotTarget = Quaternion.LookRotation(playerPos.position - this.transform.position);
            this.transform.rotation = Quaternion.RotateTowards(this.transform.rotation, rotTarget, rotateInSpeed * Time.deltaTime);
        
            if (Vector3.Angle(this.gameObject.transform.forward, this.gameObject.transform.position - playerPos.transform.position) == 0.0f)
            {
                shift = true;
            }

            if (manipulatePOV > minPOV)
            {
                manipulatePOV -= zoomInSpeed * Time.deltaTime;
            }

        }
        else
        {
            Quaternion rotTarget = Quaternion.LookRotation(planeView.position - this.transform.position);
            this.transform.rotation = Quaternion.RotateTowards(this.transform.rotation, rotTarget, rotateOutSpeed * Time.deltaTime);

            if (Vector3.Angle(this.gameObject.transform.forward, this.gameObject.transform.position - playerPos.transform.position) == 0.0f)
            {
                shift = false;
            }

            if (manipulatePOV < maxPOV)
            {
                manipulatePOV += zoomOutSpeed * Time.deltaTime;
            }

        }


    }

}
