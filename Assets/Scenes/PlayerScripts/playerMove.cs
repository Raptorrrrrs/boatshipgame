using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMove : MonoBehaviour
{
    [Header("Movement")]
    public float speed;

    public float groundDrag;

    public float jumpForce;
    public float jumpCooldown;
    public float airMultipayer;
    bool readyToJump = true;

    [Header("Keybinds")]
    public KeyCode jumpkey = KeyCode.Space;

    [Header("Ground Check")]
    public float playerHeight;
    public LayerMask whatisground;
    bool grounded;

    public Transform orientation;

    float hor;
    float vert;

    [Header("Animator")]
    public Animator animator;
    public Animator axeAnimator;

    public GameObject axe;

    Vector3 moveDir;

    Rigidbody rb;

    private int num = 0;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;

        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        grounded = Physics.Raycast(transform.position, Vector3.down, playerHeight * 0.5f + 0.2f, whatisground);

        MyInput();
        SpeedControll();

        if (grounded)
        {
            rb.drag = groundDrag;
            rb.mass = 1;
        }
        else
        {
            rb.drag = 0f;
            rb.mass = 2;
        }

        if (Input.GetMouseButton(0))
        {
            if (axe.activeSelf == false)
            {
                Punch();
            } else
            {
                AxePunch();
            }
        } else
        {
			CheckSprint();
		}
	}

    private void FixedUpdate()
    {
        MovePlayer();
    }

    private void MyInput()
    {
        hor = Input.GetAxisRaw("Horizontal");
        vert = Input.GetAxisRaw("Vertical");

        //jump
        if (Input.GetKey(jumpkey) && readyToJump)
        {
            readyToJump = false;

            Jump();

            Invoke(nameof(ResetJump), jumpCooldown);

            animator.Play("JumpAll");
        }
    }

    private void MovePlayer()
    {
        moveDir = orientation.forward * vert + orientation.right * hor;

		if (grounded)
		{
			rb.AddForce(moveDir.normalized * speed * 10f, ForceMode.Force);
		}
		else if (!grounded)
		{
			rb.AddForce(moveDir.normalized * speed * 10f * airMultipayer, ForceMode.Force);
		}
	}

    private void SpeedControll()
    {
        Vector3 vector3 = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

        if (vector3.magnitude > speed)
        {
            Vector3 limitedVel = vector3.normalized * speed;

            rb.velocity = new Vector3(limitedVel.x, rb.velocity.y, limitedVel.z);
        }
    }

    private void Jump()
    {
        rb.velocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

        rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);
    }

    private void ResetJump()
    {
        readyToJump = true;
    }

    private void CheckSprint()
    {

    }

    private void Punch()
    {
    }

    private void AxePunch()
    {
        if (Input.GetMouseButton(0))
        {
            axeAnimator.Play("axeanim");
        }
    }
}
