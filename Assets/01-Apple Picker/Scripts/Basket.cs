using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Basket : MonoBehaviour
{
    [Header("Set Dynamically")]
    public TextMeshProUGUI scoreGT;
    private float delayTime = 3f;
    private float timer;


    private void Start()
    {
        // Find a reference to the ScoreCounter GameObject
        GameObject scoreGO = GameObject.Find("ScoreCounter");
        // Get the Text Component of that GameObject
        scoreGT = scoreGO.GetComponent<TextMeshProUGUI>();
        // Set the starting number of points to 0
        scoreGT.text = "0";

    }

    // Update is called once per frame
    void Update()
    {
        /*        // Get the current screen position of the mouse from Input
                Vector3 mousePos2d = Input.mousePosition;

                // The camera's z position sets how far to push the mouse into 3D
                mousePos2d.z = -Camera.main.transform.position.z;

                // Convert the point from 2D screen space into 3D game world space
                Vector3 mousePos3D = Camera.main.ScreenToWorldPoint(mousePos2d);

                // Mover the x position of this Basket to the x position of the Mouse
                Vector3 pos = this.transform.position;
                pos.x = mousePos3D.x;

                // Exercise 3 
                // Comment this line to disable *
                pos.y = mousePos3D.y;
                // *

                this.transform.position = pos;*/


    }
    void OnCollisionEnter(Collision coll)
    {
        // Find out what hit the basket
        GameObject collidedWith = coll.gameObject;
        if (collidedWith.tag == "Apple")
        {
            Destroy(collidedWith);

            int score = int.Parse(scoreGT.text);
            score += 100;
            scoreGT.text = score.ToString();

            // Part of my attempt to implement a wave mechanic. Every 1000 points, the difficulty increases. 
            if (score % 1000 == 0)
            {
                AppleTree.IncreaseDifficulty();
            }


            
            // Track the high score
            if (score > HighScore.score)
            {
                HighScore.score = score;
            }
        }
    }

}
