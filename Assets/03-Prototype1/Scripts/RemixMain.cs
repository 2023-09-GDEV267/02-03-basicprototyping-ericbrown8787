using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemixMain : MonoBehaviour
{
    public float randomPositionTolerance;
    public float platformSpread = 10;
    public GameObject[] platforms;
    public GameObject platformPrefab;
    private GameObject player;
    private int highestReached;
    private float nextGoal;
    private int randomIndex;
    private Vector3 randomPosition;
    private Vector3 lastRandomPosition;
    // Start is called before the first frame update
    void Start()
    {
        nextGoal = Camera.main.transform.position.y;
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

        if (highestReached >= nextGoal)
        {
            randomIndex = Mathf.FloorToInt(Random.Range(0,platforms.Length));
            randomPosition = new Vector3(Random.Range(-platformSpread, platformSpread), nextGoal + 15, 0.0f);

            Instantiate(platforms[randomIndex], randomPosition, Quaternion.identity);
            nextGoal = Camera.main.transform.position.y + Camera.main.orthographicSize;
        }

       /* Debug.Log(highestReached);*/
    }

    void SpawnPlatform()
    {
        /*Instantiate(platformPrefab, Camera.ViewportToWorldPoint(new Vector2(.5f,1.2f));*/
    }
}
