using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Windows;

public class RemixPlayer : MonoBehaviour
{
    // 2D Player Controls adapted from this Unity2D tutorial: https://www.youtube.com/watch?v=24-BkpFSZuI


    public float speed = 10f;
    public float jumpForce = 16f;
    public GroundCheck groundCheck;

    private float horizontal;

    private bool isFacingRight = true;
    private Rigidbody rb;

    private bool _alive = true;
    public bool Alive
    {
        get { return _alive; }
        private set {
            _alive = value;
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
            _alive = false;
        }
            rb.velocity = new Vector3(horizontal * speed, rb.velocity.y);
            if ((!isFacingRight && horizontal > 0f) || (isFacingRight && horizontal < 0f))
            {
                OrientPlayer();
            }
        

    }
    private bool IsGrounded()
    {
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
            _alive = false;
        }
    }

}

