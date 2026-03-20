using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float speed = 7f;
    public float jumpForce = 15f;

    private float moveInput;

    private Rigidbody2D rb;
    private Joystick mobileJoystick;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        GameObject mobileJoystickObject = GameObject.FindGameObjectWithTag("ui_Joystick"); // ui
        mobileJoystick = mobileJoystickObject ? mobileJoystickObject.GetComponent<Joystick>() : null; // ui
    }

    private void Update()
    {
        rb.velocity = MoveVelocity(); // new

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }
    }

    public void Jump() // public
    {
        rb.velocity = Vector2.up * jumpForce;
    }

    // new
    private Vector2 MoveVelocity()
    {
        bool mobile = Application.isMobilePlatform;
        moveInput = mobile ? mobileJoystick.Horizontal :
            Input.GetAxis("Horizontal");

        return new Vector2(moveInput * speed, rb.velocity.y);
    }
}
