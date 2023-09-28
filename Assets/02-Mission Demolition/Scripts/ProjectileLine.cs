using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileLine : MonoBehaviour
{
    static public ProjectileLine S; //Singleton

    [Header("Set in Inspector")]
    public float minDist = .1f;
    private LineRenderer line;
    private GameObject _poi;
    private List<Vector3> points;

    private void Awake()
    {
        S = this; // Set the singleton
        
        // Get a reference to the linerenderer
        line = GetComponent<LineRenderer>();
        // Disable the lineRenderer until it's needed
        line.enabled = false;
        // Initialize the points list
        points = new List<Vector3>();

    }

    // This is a property(Method that works like a field)
    public GameObject poi
    {
        get { return _poi; }
        set { _poi = value;
            if (_poi != null) {
                // When poi is set to something new, it resets everything
                line.enabled = false;
                points = new List<Vector3>();
                AddPoint();
            }
        }
    }
    public void Clear()
    {
        _poi = null;
        line.enabled=false;
        points = new List<Vector3>();

    }

    public void AddPoint()
    {
        //This is called to add a point to the line
        Vector3 pt = _poi.transform.position;

        if (points.Count > 0  && (pt - lastPoint).magnitude < minDist ){
            // If the point isn't far away enough from the last point, it returns
            return;
        }

        if (points.Count == 0 ) // If this is the launch point
        {
            Vector3 launchPosDiff = pt - Slingshot.LAUNCH_POS; // to be defined
            //It adds an extra bit of line to aid aiming later
            points.Add( pt + launchPosDiff );
            points.Add(pt);
            line.positionCount = 2;
            //Sets the first two points
            line.SetPosition(0, points[0]);
            line.SetPosition(1, points[1]);
            //Enables the linerenderer
            line.enabled = true;
        }
        else
        {
            points.Add(pt);
            line.positionCount=points.Count;
            line.SetPosition(points.Count - 1, lastPoint);
            line.enabled = true;

        }

    }


    public Vector3 lastPoint
    {
        get        {
            if(points == null)
            {
                //If there are no points, return Vector3.zero
                return Vector3.zero;
            }
            return (points[points.Count - 1]);
        }

    }

    private void FixedUpdate()
    {
        if (poi == null)
        {
            // If there is no POI, search for one
            if (FollowCam.POI != null)
            {
                if (FollowCam.POI.tag == "Projectile")
                {
                    poi = FollowCam.POI;
                }
                else
                {
                    return;
                }
            } 
            else
            {
                return;//return if we didn't find a POI
            }
            
        }
        // If there is a poi, its loc is added every FixedUpdate()
        AddPoint();
        if (FollowCam.POI == null)
        {
            //Once followcam POI is null, make local poi null too
            poi = null;
        }
    }
}
