using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public bool yMovementEnabled = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Get the current screen position of the mouse from Input
        Vector3 mousePos2d = Input.mousePosition;

        // The camera's z position sets how far to push the mouse into 3D
        mousePos2d.z = -Camera.main.transform.position.z;

        // Convert the point from 2D screen space into 3D game world space
        Vector3 mousePos3D = Camera.main.ScreenToWorldPoint(mousePos2d);

        // Mover the x position of this Basket to the x position of the Mouse
        Vector3 pos = this.transform.position;
        pos.x = mousePos3D.x;

        // Exercise 3 
        // Comment this line to disable
        if (yMovementEnabled)
        {
            pos.y = mousePos3D.y;
        }

        this.transform.position = pos;
    }
}
