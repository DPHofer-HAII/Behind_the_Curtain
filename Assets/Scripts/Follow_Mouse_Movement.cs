using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow_Mouse_Movement : MonoBehaviour
{
    //Camera mycam = Camera.main;
    private float mouseSensitivity = 4f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //transform.LookAt(mycam.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, mycam.nearClipPlane)), Vector3.up);
        MyRotate();
    }

    void MyRotate()
    {
        float horizontalRotation = Input.GetAxis("Mouse X");
        float verticalRotation = Input.GetAxis("Mouse Y");

        transform.Rotate(0, horizontalRotation * mouseSensitivity, 0);
    }
}
