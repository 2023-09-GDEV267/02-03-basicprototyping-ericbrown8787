using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using UnityEngine;

public class StormCloud : MonoBehaviour
{
    public GameObject ammoPrefab;
    public float lightningForceMultiplier = 1.0f;
    public float speed = 10f;
    public float leftAndRightEdge = 10f;
    public float chanceToChangeDirections = 0.1f;
    public float secondsBetweenDrops = 1f;

    // Start is called before the first frame update
    void Start()
    {
        Invoke("Attack", secondsBetweenDrops);
    }

    // Update is called once per frame
    void Update()
    {

        Vector3 pos = transform.position;

        if (pos.x < -leftAndRightEdge)
        {
            speed = Mathf.Abs(speed);
        }
        else if (pos.x > leftAndRightEdge)
        {
            speed = -Mathf.Abs(speed);
        }

        pos.x += speed * Time.deltaTime;
        transform.position = pos;
        transform.position = pos;
    }

    private void FixedUpdate()
    {
        Vector3 pos = transform.position;


        if (Random.value < chanceToChangeDirections)
        {
            speed *= -1;
        }

    }
    void Attack()
    {
        GameObject apple = Instantiate<GameObject>(ammoPrefab);
        apple.GetComponent<Rigidbody>().AddForce(Vector3.down * lightningForceMultiplier, ForceMode.Impulse);
        apple.transform.position = transform.position;
        Invoke("Attack", secondsBetweenDrops);
    }
}
