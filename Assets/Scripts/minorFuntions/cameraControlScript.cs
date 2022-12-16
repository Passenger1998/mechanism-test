//using System.Collections;
//using System.Collections.Generic;
//using UnityEditor.Experimental.GraphView;
//using UnityEngine;
//using static UnityEngine.GraphicsBuffer;

//public class cameraControlScript : MonoBehaviour
//{

//    public Transform plain_sight;
//    public Transform focusOnPlayer;

//    float fieldOfView;

//    void Awake()
//    {
//        fieldOfView = this.gameObject.GetComponent<Camera>().fieldOfView;

//        //shift = false;

//        this.gameObject.transform.LookAt(plain_sight);

//        fieldOfView = 20;
//    }

//    //bool shift;

//    // Start is called before the first frame update
//    void Start()
//    {
        
//    }

//    // Update is called once per frame
//    void Update()
//    {

//        fieldOfView = fieldOfView + Input.GetAxis("Mouse ScrollWheel");

//        //ShiftFocusTarget();

//    }

//    //void ShiftFocusTarget_1()
//    //{
//    //    if (Input.GetKeyDown("f") && !shift)
//    //    {
//    //        Quaternion neededRotation = Quaternion.LookRotation((focusOnPlayer.gameObject.transform.position - transform.position));
//    //        this.gameObject.transform.rotation = Quaternion.RotateTowards(transform.rotation, neededRotation, Time.deltaTime * 10f);
//    //        shift = true;
//    //    } else if (Input.GetKeyDown("f") && shift)
//    //    {

//    //        Quaternion neededRotation = Quaternion.LookRotation((plain_sight.gameObject.transform.position - transform.position));
//    //        this.gameObject.transform.rotation = Quaternion.RotateTowards(transform.rotation, neededRotation, Time.deltaTime * 10f);
//    //        shift=false;
//    //    }
//    //}

//    //void ShiftFocusTarget()
//    //{
//    //    if (Input.GetAxis("Mouse ScrollWheel") > 0f) // forward
//    //    {
//    //        this.gameObject.transform.Rotate(0.0f, -26.593f, 0.0f);
//    //        transform.LookAt(focusOnPlayer);
//    //    }
//    //    else if (Input.GetAxis("Mouse ScrollWheel") < 0f) // backwards
//    //    {
//    //        transform.LookAt(plain_sight);
//    //    }
//    //}

//}
