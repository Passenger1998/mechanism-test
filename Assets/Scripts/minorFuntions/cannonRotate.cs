using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cannonRotate : MonoBehaviour
{

    public Vector2 turn;
    public float sensitivity = .5f;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        turn.y += Input.GetAxis("Mouse Y") * sensitivity;
        transform.localRotation = Quaternion.Euler(0, turn.y, 0);
    }
}
