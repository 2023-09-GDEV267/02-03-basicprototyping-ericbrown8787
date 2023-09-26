using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class RemixRigidbodySleep : MonoBehaviour
{
    private Rigidbody rb;
    private Rigidbody[] siblings;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        
        if (rb != null) rb.Sleep();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision coll)
    {
        // Find out what hit the basket
        GameObject collidedWith = coll.gameObject;
        if (collidedWith.tag == "SlingshotAmmo")
        {
            if(transform.parent){
                siblings = transform.parent.GetComponentsInChildren<Rigidbody>();
                foreach (Rigidbody sibling in siblings)
                {
                    sibling.isKinematic = false;

                }

            } else
            {
                rb.isKinematic = false;
            }



        }
    }
}
