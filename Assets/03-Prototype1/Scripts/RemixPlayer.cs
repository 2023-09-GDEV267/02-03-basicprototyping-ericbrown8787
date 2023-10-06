using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Windows;

public class RemixPlayer : MonoBehaviour
{

    public float speed = 10f;
    public float jumpForce = 16f;
    public GroundCheck groundCheck;

    private float horizontal;

    private bool isFacingRight = true;
    private Rigidbody rb;

    private bool alive = true;
    public bool Alive
    {
        get { return alive; }
        private set {
            alive = value;
        }   
    }

    private void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
    }
    private void FixedUpdate()
    {
        // Player dies if they fall below the camera viewport
        if (transform.position.y < Camera.main.transform.position.y - 15)
        {
            alive = false;
        }
            rb.velocity = new Vector3(horizontal * speed, rb.velocity.y);
            if ((!isFacingRight && horizontal > 0f) || (isFacingRight && horizontal < 0f))
            {
                OrientPlayer();
            }
        

    }
    private bool IsGrounded()
    {
        /*return Physics.Raycast(transform.position, Vector3.down, groundTolerance);*//*
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);*/
        return groundCheck.IsGrounded();


    }


    private void OrientPlayer()
    {
        isFacingRight = !isFacingRight;
        Vector3 localScale = transform.localScale;
        localScale.x *= -1f;
        transform.localScale = localScale;
    }

    public void Move(InputAction.CallbackContext context)
    {
        horizontal = context.ReadValue<Vector2>().x;
    }

    public void Jump(InputAction.CallbackContext context)
    {
        if (context.performed && IsGrounded())
        {
           
            rb.AddForce(new Vector3(0, jumpForce, 0.0f), ForceMode.Impulse);
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Lightning")
        {
            alive = false;
        }
    }

}

