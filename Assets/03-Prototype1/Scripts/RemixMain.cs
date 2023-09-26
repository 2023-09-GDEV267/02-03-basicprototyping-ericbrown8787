using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemixMain : MonoBehaviour
{
    public GameObject platformPrefab;
    private GameObject player;
    private int highestReached;
    
    
    // Start is called before the first frame update
    void Start()
    {
        highestReached= 0;
        player = GameObject.Find("Player");
    }



    // Update is called once per frame
    void Update()
    {
        if (player.transform.position.y > highestReached)
        {
            highestReached = Mathf.RoundToInt(player.transform.position.y);
        }
        Debug.Log(highestReached);
    }

    void SpawnPlatform()
    {
        /*Instantiate(platformPrefab, Camera.ViewportToWorldPoint(new Vector2(.5f,1.2f));*/
    }
}
