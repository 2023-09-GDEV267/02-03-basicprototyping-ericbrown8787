using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Windows;

public class RemixPlayer : MonoBehaviour
{


    public Transform groundCheck;
    public LayerMask groundLayer;
    public float speed = 10f;
    public float jumpForce = 16f;

    private float horizontal;

    private bool isFacingRight = true;
    public float groundTolerance = 1.5f;
    private Rigidbody rb;
    private void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
    }
    private void FixedUpdate()
    {

        rb.velocity = new Vector3(horizontal * speed, rb.velocity.y);
        if ((!isFacingRight && horizontal > 0f) || (isFacingRight && horizontal < 0f))
        {
            OrientPlayer();
        }
    }
    private bool IsGrounded()
    {
        /*return Physics.Raycast(transform.position, Vector3.down, groundTolerance);*/
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);



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

}

