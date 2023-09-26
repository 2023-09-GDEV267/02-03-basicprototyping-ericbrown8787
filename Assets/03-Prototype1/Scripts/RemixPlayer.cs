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
    public float maxForce = 1;
    public float groundTolerance = 1.5f;
    public LayerMask layerMask;

    private Rigidbody rb;
    private float movementX;
    private float movementY;
    private bool isJumping;
    private SphereCollider toleranceSphere;


    public HandheldSlingshot weapon;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        toleranceSphere = GetComponent<SphereCollider>();
    }
    void OnMove(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();
        movementX = movementVector.x;
        movementY = movementVector.y;
        
    }

    void OnJump(InputValue jumpValue)
    {
        if (!IsGrounded()) return;
        isJumping = true;
    }

    void OnFire()
    {
        weapon.FireProjectile();
    }


    private bool IsGrounded()
    {
        return Physics.Raycast(transform.position, Vector3.down, groundTolerance);

   



    }
    void FixedUpdate()
    {
        /*      Vector3 currentVelocity = rb.velocity;
              Vector3 targetVelocity = new Vector3(move.x, move.y, 0);
              targetVelocity *= speed;


              Vector3 velocityChange = targetVelocity- currentVelocity;

              Vector3.ClampMagnitude(velocityChange, maxForce);

              rb.AddForce(velocityChange, ForceMode.VelocityChange);*/


        if (movementX > 0)
        {
            rb.velocity = new Vector3(speed, rb.velocity.y, 0.0f);

        }
        else if (movementX < 0)
        {
            rb.velocity = new Vector3(-speed, rb.velocity.y, 0.0f);
        }
        if (movementY != 0) movementY = 0;

        Vector3 movement = new Vector3(movementX, movementY, 0.0f);
   /*     rb.AddForce(movement*speed*Time.fixedDeltaTime);*/


        if (isJumping)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isJumping = false;
        }
    }

}

