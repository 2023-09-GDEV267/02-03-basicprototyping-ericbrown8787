using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCam : MonoBehaviour
{
    static public GameObject POI; // the static point of interest

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
        if (POI == null) return;
        
        //Get the position of the POI
        Vector3 destination = POI.transform.position;
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
