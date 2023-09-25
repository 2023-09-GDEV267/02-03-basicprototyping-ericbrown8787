using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Apple;

public class RemixFollowCam : MonoBehaviour
{
    public GameObject POI; // the static point of interest

    [Header("Set in Inspector")]
    public float easing = .05f;
    public Vector2 minXY= Vector2.zero;

    [Header("Set Dynamically")]
    public float camZ;    // The desired zPos of the camera
void Awake()
    {
        camZ = this.transform.position.z;  
    }

    void FixedUpdate()
    {

        /* 
                if (POI == null) return;

                //Get the position of the POI
                Vector3 destination = POI.transform.position;
        */
        Vector3 destination;
        // if there is no POI, return to P: [0,0,0]
        if (POI== null)
        {
            destination = Vector3.zero;
        }
        else
        {
            // Get the position of the POI
            destination = POI.transform.position;
            // If POI is a projectile, check to see if it's at rest.
            if (POI.tag == "Projectile")
            {
                // If it is sleeping(not moving)
                if (POI.GetComponent<Rigidbody>().IsSleeping())
                {
                    // Return to default view
                    POI = null;
                    // In the next update
                }
            }
        }
        destination = Vector3.Lerp(transform.position, destination, easing);

        // Limit the X and Y to minimum values
        destination.x =Mathf.Max(minXY.x, destination.x);
        destination.y =Mathf.Max(minXY.y, destination.y);

        // Force destination.z to be camZ to keep the camera far enough away
        destination.z = camZ;

        // Set the camera to the destination
        transform.position = destination;

        // Set the orthographicSize of the Camera to keep ground in view
        Camera.main.orthographicSize = destination.y + 10;


    }
}
