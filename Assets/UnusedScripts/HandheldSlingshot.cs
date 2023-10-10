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
    public GameObject player;
    public GameObject rightSlingshotModel;
    public GameObject leftSlingshotModel;
/*    private bool facingRight = true;*/
    // Start is called before the first frame update
    void Start()
    {
        /*leftSlingshotModel = Instantiate(rightSlingshotModel);*/
       /* leftSlingshotModel.transform.localScale = new Vector3(-leftSlingshotModel.transform.localScale.x, -leftSlingshotModel.transform.localScale.y, leftSlingshotModel.transform.localScale.z);*/
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 slingshotPosition = transform.position;
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 direction = (mousePosition - slingshotPosition).normalized;



        



        if (mousePosition.x < player.transform.position.x)
        {
/*            facingRight = false;*/
            player.transform.eulerAngles = new Vector3(player.transform.rotation.x, 180, player.transform.rotation.z);


        }
        else
        {

/*            facingRight= true;*/


            player.transform.eulerAngles = new Vector3(player.transform.rotation.x, 0, player.transform.rotation.z);



        }



        transform.right = direction;

    }


    public void FireProjectile()
    {
        GameObject projectile = Instantiate(slingshotProjectilePrefab, launchPoint.position, launchPoint.rotation);
        projectile.GetComponent<Rigidbody>().velocity=transform.right*launchForce;
    }

}
