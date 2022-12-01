using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class cameraControlScript1 : MonoBehaviour
{
    public float speed;
    public Transform playerPos;
    public Transform planeView;

    private void Update()
    {
        Quaternion rotTarget = Quaternion.LookRotation(playerPos.position - this.transform.position);
        this.transform.rotation = Quaternion.RotateTowards(this.transform.rotation, rotTarget, speed * Time.deltaTime);
    }

}
