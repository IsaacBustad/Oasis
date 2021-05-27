using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeSpeed : MonoBehaviour
{
    // local vars
    // obj to change
    public MovePlayer movePlayer;
    public float speedMult = 1f;

    // possible max mults
    public float runMult = 2f;
    public float walkMult = 1f;
    public float crouchMult = .5f;

    // possible accell and decell
    public float runAccell = 2f;
    public float walkDecell = 1f;
    public float crouchDecell = .5f;

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
                this.isCrouching = false;
            }

            if (Input.GetButtonDown("Crouch"))
            {
                this.isCrouching = !this.isCrouching;
                this.isRunning = false;
            }         
            
            if (Input.GetButtonDown("Jump"))
            {
                this.isCrouching = false;
            }

        }

        SetSpeed();
    }

    // process actions
    private void SetSpeed()
    {
        if (this.isRunning == true)
        {
            this.speedMult += this.runAccell * speedMult * Time.deltaTime;            
        }

        else if (this.isCrouching == true)
        {
            this.speedMult -= this.crouchDecell * speedMult * Time.deltaTime;
        }

        else if (this.isCrouching == false && this.isRunning == false)
        {
            if (Mathf.Abs(this.speedMult) - 1f <= 0.1f)
            {
                this.speedMult = 1f;
            }

            else if (this.speedMult < 1)
            {
                this.speedMult += this.walkDecell * this.speedMult * Time.deltaTime;
            }

            else if (this.speedMult > 1)
            {
                this.speedMult -= this.walkDecell * this.speedMult * Time.deltaTime;
            }
        }

        this.speedMult = Mathf.Clamp(this.speedMult, this.crouchMult, this.runMult);

        this.movePlayer.speedMultiplier = this.speedMult;
    }


}
