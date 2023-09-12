using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleTree : MonoBehaviour
{
    public GameObject applePrefab;
    public static float speed = 10f;
    public float leftAndRightEdge = 10f;
    public float chanceToChangeDirections = 0.1f;
    public static float secondsBetweenAppleDrops = 1f;

    // Start is called before the first frame update
    void Start()
    {
        Invoke("DropApple", 2f);
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
    }

    private void FixedUpdate()
    {
        Vector3 pos = transform.position;


        if (Random.value < chanceToChangeDirections)
        {
            speed *= -1;
        }
    }
    void DropApple()
    {
        GameObject apple = Instantiate<GameObject>(applePrefab);
        apple.transform.position = transform.position;
        Invoke("DropApple", secondsBetweenAppleDrops);
    }

    public static void IncreaseDifficulty()
    {
        // My attempt to implement a waves mechanic with increasing difficulty. 
        if (speed < 0)
        {
            speed -= 2f; 
        } 
        else
        {
            speed += 2f;
        }

        secondsBetweenAppleDrops -= .1f;

    }
}
