using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using UnityEngine;

public class AppleTree : MonoBehaviour
{
    public GameObject applePrefab;
    public static float speed = 10f;
    public float leftAndRightEdge = 10f;
    public float chanceToChangeDirections = 0.1f;
    public static float secondsBetweenAppleDrops = 1f;
    private static bool isPaused = false;
    public static float delayTime = 3f;
    private static float timer = 0f;

    // Start is called before the first frame update
    void Start()
    {


        Invoke("DropApple", 2f);
    }

    // Update is called once per frame
    void Update()
    {

        if (isPaused)
        {
            if (timer < Time.time)
            {
                isPaused = false;
                timer = 0f;
            }
            else return;
        }

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
        if (isPaused) return;
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
        timer = Time.time + delayTime;
        isPaused = true;
        GameObject[] tAppleArray = GameObject.FindGameObjectsWithTag("Apple");
        foreach (GameObject tGO in tAppleArray)
        {
            Destroy(tGO);
        }

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

    public static void ResetDifficulty()
    {
        speed = 10f;
        secondsBetweenAppleDrops = 1f;
    }
}
