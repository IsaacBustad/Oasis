using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCamera : MonoBehaviour
{
    // local vars
    public Transform playerBody;
    public float sensitivity = 10;

    public float mouseX;
    public float mouseY;
    public float xRot;
    

    private void Awake()
    {
        Cursor.lockState = CursorLockMode.Locked;
        
    }

    // Update is called once per frame
    void Update()
    {
        SenseInput(); 

    }

    private void SenseInput()
    {
        //this.movement.x = Input.GetAxis("Horizontal");
        //this.movement.z = Input.GetAxis("Vertical");
        this.mouseX = Input.GetAxis("Mouse X") * this.sensitivity * Time.deltaTime;
        this.mouseY = Input.GetAxis("Mouse Y") * this.sensitivity * Time.deltaTime;

        Rotate();
        
    }

    

    private void Rotate()
    {
        xRot -= mouseY;
        xRot = Mathf.Clamp(xRot, -90f, 90f);

        this.transform.localRotation = Quaternion.Euler(xRot, 0f, 0f);
        this.playerBody.Rotate(Vector3.up * mouseX);
    }

}
