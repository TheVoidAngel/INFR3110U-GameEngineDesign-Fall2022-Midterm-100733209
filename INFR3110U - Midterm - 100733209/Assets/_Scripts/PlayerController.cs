using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public static PlayerController instance;
    //player movement
    public PlayerCharAction inputAction;

    Vector2 move;
    Vector2 rotate;
    private float walkSpeed = 10f;
    public Camera playerCamera;
    Vector3 cameraRotation;

    //player jump
    Rigidbody rb;
    private float diatanceToGround;
    private bool isGrounded = true;
    public float jump = 5f;

    //player animation
    private Animator playerAnimator;
    private bool isWalking = false;

    //projectile bullets
    public GameObject bullet;
    public Transform projectilePos;

    // Start is called before the first frame update
    void Start()
    {
        if(!instance)
        {
            instance = this;
        }

        inputAction = PlayerInputController.controller.inputAction;

        inputAction.Player.Move.performed += cntxt => move = cntxt.ReadValue<Vector2>();
        inputAction.Player.Move.canceled += cntxt => move = Vector2.zero;

        inputAction.Player.Jump.performed += cntxt => Jump();

        inputAction.Player.Shoot.performed += cntxt => Shoot();

        rb = GetComponent<Rigidbody>();

        playerAnimator = GetComponent<Animator>();
        diatanceToGround = GetComponent<Collider>().bounds.extents.y;
    }
    
    private void Jump()
    {
        if(isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jump);
            isGrounded = false;
        } 
    }

    private void Shoot()
    {
        Rigidbody bulletRb = Instantiate(bullet, projectilePos.position, Quaternion.identity).GetComponent<Rigidbody>();
        bulletRb.AddForce(transform.forward * 32f, ForceMode.Impulse);
        bulletRb.AddForce(transform.up * 5f, ForceMode.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * move.y * Time.deltaTime * walkSpeed, Space.Self);
        transform.Translate(Vector3.right * move.x * Time.deltaTime * walkSpeed, Space.Self);

        isGrounded = Physics.Raycast(transform.position, -Vector3.up, diatanceToGround);
        
    }
}
