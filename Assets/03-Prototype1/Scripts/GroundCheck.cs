using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    //Groundcheck class attached to a GameObject with collider to report whether player is on the ground
    private bool isGrounded=true;

    private void OnTriggerEnter(Collider coll)
    {
        if (coll.gameObject.tag == "Ground")
        {
            isGrounded = true;
        }
    }

    private void OnTriggerExit(Collider coll)
    {
        if (coll.gameObject.tag == "Ground")
        {
            isGrounded = false;
        }
    }

    public bool IsGrounded()
    {
        return isGrounded;
    }
}
