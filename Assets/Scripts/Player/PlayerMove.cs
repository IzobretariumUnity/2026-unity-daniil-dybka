using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public Transform groundPoint; // new
    public LayerMask groundLayer; // new

    public float speed = 7f;
    public float jumpForce = 15f;

    private float moveInput;

    private Rigidbody2D rb;
    private Joystick mobileJoystick;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        GameObject mobileJoystickObject = GameObject.FindGameObjectWithTag("ui_Joystick");
        mobileJoystick = mobileJoystickObject ? mobileJoystickObject.GetComponent<Joystick>() : null;

        if (Application.isMobilePlatform == false)
        {
            GameObject mobileButtonJump = GameObject.FindGameObjectWithTag("ui_ButtonJump");
            mobileButtonJump.SetActive(false);

            mobileJoystickObject.SetActive(false);
        }
    }

    private void Update()
    {
        rb.velocity = MoveVelocity();

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }
    }

    public void Jump()
    {
        if (Ground()) // new
        {
            rb.velocity = Vector2.up * jumpForce;
        }
    }

    private Vector2 MoveVelocity()
    {
        bool mobile = Application.isMobilePlatform;
        moveInput = mobile ? mobileJoystick.Horizontal :
            Input.GetAxis("Horizontal");

        return new Vector2(moveInput * speed, rb.velocity.y);
    }

    private Collider2D Ground() // new
    {
        return Physics2D.OverlapCircle(groundPoint.position, 0.1f, groundLayer);
    }
}
