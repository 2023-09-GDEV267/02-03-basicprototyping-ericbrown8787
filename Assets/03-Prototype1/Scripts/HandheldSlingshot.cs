using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Unity.IO.LowLevel.Unsafe;
using UnityEngine;

public class HandheldSlingshot : MonoBehaviour
{
    public GameObject slingshotProjectilePrefab;
    public float launchForce;
    public Transform launchPoint;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 slingshotPosition = transform.position;
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 direction = mousePosition - slingshotPosition;
        transform.right = direction;

        if (Input.GetMouseButtonDown(0))
        {
            FireProjectile();
        }
    }

    void FireProjectile()
    {
        GameObject projectile = Instantiate(slingshotProjectilePrefab, launchPoint.position, launchPoint.rotation);
        projectile.GetComponent<Rigidbody>().velocity=transform.right*launchForce;
    }

}
