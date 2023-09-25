using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Windows;

public class RemixPlayer : MonoBehaviour
{
    public float horizontal;
    public float speed = 13f;
    public float jumpForce = 25f;
    public float playerAcceleration = .5f;

    private bool orientation = true;

    private Rigidbody rb;
    private float movementX;
    private float movementY;
    private bool isJumping;


    public HandheldSlingshot weapon;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    void OnMove(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();
        movementX = movementVector.x;
    }

    void OnJump(InputValue jumpValue)
    {
        if (!IsGrounded()) return;
        isJumping = true;
    }

    void OnFire()
    {
        Debug.Log("fire");
        weapon.FireProjectile();
    }


    private bool IsGrounded()
    {
        return Physics.Raycast(transform.position, Vector3.down, 1.5f);
    }
    void FixedUpdate()
    {
        float xVelocity = speed;       
        
            if (movementX > 0)
            {
            rb.velocity = new Vector3(xVelocity, rb.velocity.y, 0.0f);
            /* rb.MovePosition(transform.position + movementVector * Time.deltaTime * speed);*/
        }
            else if (movementX < 0)
            {
                rb.velocity = new Vector3(-xVelocity, rb.velocity.y, 0.0f);
            }
            if (movementY != 0) movementY = 0;

    

        Vector3 movement = new Vector3(0.0f, movementY, 0.0f);
        rb.AddForce(movement * speed);
 


        if (isJumping)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isJumping = false;
        }
    }

}

