using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemixMain : MonoBehaviour
{
  /*  [Range(0,1)]public float chanceToSpawnTwoPlatforms = .5f;*/
    public float randomPositionTolerance = 10;
    public float platformSpread = 10;
    public GameObject[] platforms;
    private GameObject player;
    private int highestReached;
    private float nextGoal;
    private Vector3 randomPosition;
    private Vector3 lastRandomPosition;
    private bool newPlatformSpawned = false;
/*    private bool secondPlatformSpawned = false;*/
    
    // Start is called before the first frame update
    void Start()
    {
        nextGoal = 10;
        highestReached = 0;
        player = GameObject.Find("Player");
    }



    // Update is called once per frame
    void Update()
    {
        if (player.transform.position.y > highestReached)
        {
            highestReached = Mathf.RoundToInt(player.transform.position.y);
        }


       /* Debug.Log(highestReached);*/
    }

    private void FixedUpdate()
    {

        if (highestReached >= nextGoal && !newPlatformSpawned)
        {
            Debug.Log("ding");
            SpawnPlatform();
        }
    }

    void SpawnPlatform()
    {
        randomPosition = new Vector3(Random.Range(-platformSpread, platformSpread), nextGoal + 20, 0.0f);
        if (randomPosition.x < lastRandomPosition.x + randomPositionTolerance && randomPosition.x > lastRandomPosition.x - randomPositionTolerance)
        {
            //Start over if platforms are too close
            SpawnPlatform();
        }
        else
        {
            int randomIndex = Mathf.FloorToInt(Random.Range(0, platforms.Length));
            Instantiate(platforms[randomIndex], randomPosition, Quaternion.identity);
            lastRandomPosition = randomPosition;
/*            if (secondPlatformSpawned == false&&Random.value < chanceToSpawnTwoPlatforms)
            {
                Debug.Log("Second platform spawned");
                secondPlatformSpawned = true;
                SpawnPlatform();
            }
            secondPlatformSpawned = false;*/
            nextGoal += 10;
/*            newPlatformSpawned = true;*/
        }
        
    }
}
