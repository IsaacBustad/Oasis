using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeSpeed : MonoBehaviour
{
    // local vars
    // obj to change
    public MovePlayer movePlayer;

    // possible speeds
    public float runSpeed = 2f;
    public float walkSpeed = 1f;
    public float sneakSpeed = .5f;

    // checking states of walk sprint
    public bool isRunning = false;
    public bool isCrouching = false;
    public bool isWalking = false;

    private void Awake()
    {
        movePlayer = gameObject.GetComponent<MovePlayer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (this.movePlayer.isGrounded == true)
        {

            if (Input.GetButtonDown("Sprint"))
            {
                this.isRunning = !this.isRunning;
            }

            if (Input.GetButtonDown("Crouch"))
            {
                this.isCrouching = !this.isCrouching;
            }

            if (Input.GetButtonDown("Sprint"))
            {
                this.isWalking = !this.isWalking;
            }

        }



    }

    // process actions
    private void SetSpeed()
    {

    }


}
