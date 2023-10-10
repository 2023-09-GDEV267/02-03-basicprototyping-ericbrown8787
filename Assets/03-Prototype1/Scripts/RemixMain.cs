using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.SocialPlatforms.Impl;

public class RemixMain : MonoBehaviour
{
  /*  [Range(0,1)]public float chanceToSpawnTwoPlatforms = .5f;*/
    [Range(0,11)]public float randomPositionTolerance = 10;
    [Range(10,15)]public float platformSpread = 15;
    public GameObject[] platforms;
    public RemixPlayer player;
    public TextMeshProUGUI highScoreUI;
    public TextMeshProUGUI currentAltitudeUI;
    private int highestReached;
    private int highScore;
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
    }

    void Awake()
    {
        // If the PlayerPrefs HighScore already exists, read it
        if (PlayerPrefs.HasKey("RemixHighScore"))
        {
            highScore = PlayerPrefs.GetInt("RemixHighScore");
        }

        PlayerPrefs.SetInt("RemixHighScore", highScore);
    }

    // Update is called once per frame
    void Update()
    {
        if (!player.Alive)
        {
            SceneManager.LoadScene("Main-Prototype 1");
        }
        if (player.transform.position.y > highestReached)
        {
            highestReached = Mathf.RoundToInt(player.transform.position.y);
        }

        currentAltitudeUI.text = $"Altitude: {Mathf.Round(player.transform.position.y)}m";

        

        // Update the PlayerPrefs score if necessary
        if (highestReached > PlayerPrefs.GetInt("RemixHighScore"))
        {
            PlayerPrefs.SetInt("RemixHighScore", highestReached);
            
        }
        highScoreUI.text = $"High Score: {highScore}m";
        /* Debug.Log(highestReached);*/
    }

    private void FixedUpdate()
    {

        if (highestReached >= nextGoal && !newPlatformSpawned)
        {
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
