using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class RemixPlayer : MonoBehaviour
{
    public float speed = 10;
    public float jumpForce = 60;

    private Rigidbody rb;
    private float movementX;
    private float movementY;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    void OnMove(InputValue movementValue)
    {
        Debug.Log("move");
        Vector2 movementVector = movementValue.Get<Vector2>();
        movementX = movementVector.x;
    }

    void OnJump()
    {
        if (rb.velocity.y != 0 || !Physics.Raycast(transform.position, Vector3.down, 1.3f)) return;
            Debug.Log("Jump");
            movementY = jumpForce; movementY = jumpForce;
        


    }

    void OnFire()
    {
        Debug.Log("fire");
    }

    void FixedUpdate()
    {

        Vector3 movement = new Vector3(movementX, movementY, 0.0f);
        rb.AddForce(movement * speed);
        if (movementY != 0) movementY = 0;
        /*Debug.Log(movementX * speed);*/
    }

}

