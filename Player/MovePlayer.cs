using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : MonoBehaviour
{
    // local vars
    public Rigidbody playerRb;
    public CharacterController playerController;     
    public Animator animator;    
    public State playerState;
    //public Vector3 wallPushOf;

    // speed the player moves    
    public float forwardSpeed = 10f;
    public float backwardSpeed = 10f;
    public float straifSpeed = 10f;
    public float speedMultiplier = 1f;    
    public float externalMultiplier;

    // gravity
    public float velocity;
    public float gravity = -9.81f;
   
    
    // movement direction
    public float moveX;
    public float moveZ;
    public Vector3 move;
    public float jumpHeight = 3f;

    // ground check
    public Transform groundCheck;
    public float groundDistance;
    public LayerMask groundMask;
    public LayerMask wallMask;
    public int groundLayer = 11;
    public int wallLayer = 6;
    public bool isGrounded = false;
    public bool isOnWall = false;
    public GameObject lastWall;
    public GameObject currentWall;

    private void Awake()
    {
        this.playerController = gameObject.GetComponent<CharacterController>();
        this.playerRb = gameObject.GetComponent<Rigidbody>();
    }


    // Update is called once per frame
    void Update()
    {
        this.isGrounded = Physics.CheckSphere(this.groundCheck.position, this.groundDistance, this.groundMask);
        this.isOnWall = Physics.CheckSphere(this.groundCheck.position, this.groundDistance, this.wallMask);
        SenseInput();
    }


    private void SenseInput()
    {
        this.moveX = Input.GetAxis("Horizontal");
        this.moveZ = Input.GetAxis("Vertical");


        if (this.isGrounded == false)
        {
            if (this.isOnWall == false)
            {
                this.currentWall = null;
                this.lastWall = null;
            }

            if (this.isOnWall == true)
            {
                this.velocity = Mathf.Clamp(this.velocity, -2f, Mathf.Infinity);
            }

            if (Input.GetButtonDown("Jump") && this.isOnWall == true)
            {
                if (this.currentWall != this.lastWall)
                {
                    this.velocity = Mathf.Sqrt(this.jumpHeight * -2f * this.gravity);
                }

                //this.playerRb.MovePosition(this.playerRb.position + this.wallPushOf);

                this.lastWall = this.currentWall;

            }
        }


        if (this.isGrounded == true)
        {
            this.currentWall = null;
            this.lastWall = null;
            if (velocity < 0)
            {
                this.velocity = Mathf.Clamp(this.velocity, -2f, Mathf.Infinity);
            }

            if (Input.GetButtonDown("Jump") && this.isGrounded == true)
            {

                this.velocity = Mathf.Sqrt(this.jumpHeight * -2f * this.gravity);

            }
        }


        UpdateAnimationAndMove();
    }

    // update animator variables
    private void UpdateAnimationAndMove()
    {
        this.velocity += this.gravity * Time.deltaTime;
        this.move = this.transform.right * this.moveX * this.straifSpeed * this.speedMultiplier + 
                    this.transform.forward * this.moveZ * this.forwardSpeed * this.speedMultiplier + 
                    this.transform.up * this.velocity;
        this.playerController.Move(move * Time.deltaTime);       
        
    }


    // get object of current wall to limit consecutive jumps on wall
    private void OnTriggerEnter(Collider otherObj)
    {
        if (otherObj.gameObject.layer == this.wallLayer && this.isGrounded == false)
        {                    
            this.currentWall = otherObj.gameObject;
            //this.wallPushOf = ((this.playerRb.position - this.currentWall.transform.position) * 10).normalized;
            //this.wallPushOf.y = 0;
        }
    }


    

}
