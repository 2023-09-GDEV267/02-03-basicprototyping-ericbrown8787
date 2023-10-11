using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class RemixRigidbodySleep : MonoBehaviour
{
   
    public int durability = 4;
    private Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        
        if (rb != null) rb.Sleep();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // Destroying platforms as we climb
        if (transform.position.y < Camera.main.transform.position.y - 12.5f)
        {
            rb.isKinematic = false;

        }
        
        if (transform.position.y < Camera.main.transform.position.y - 30)
        {
            Destroy(this.gameObject);
            Destroy(this);
        }

    }

    void OnCollisionEnter(Collision coll)
    {
        // Find out what hit the basket
        GameObject collidedWith = coll.gameObject;
        if (collidedWith.tag == "Lightning")
        {
        if (durability >0)
            {
                durability -= 1;
            }
        else
            {
                rb.isKinematic= false;
            }


        }
    }


}
