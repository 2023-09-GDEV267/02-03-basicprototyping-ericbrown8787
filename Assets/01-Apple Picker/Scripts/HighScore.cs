using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; // Instead of UnityEngine.UI

public class HighScore : MonoBehaviour
{
    public static int score = 1000;

    void Awake()
    {
        // If the PlayerPrefs HighScore already exists, read it
        if (PlayerPrefs.HasKey("HighScore"))
        {
            score = PlayerPrefs.GetInt("HighScore");
        }

        PlayerPrefs.SetInt("HighScore", score);
    }
    // Update is called once per frame
    void Update()
    {
        TextMeshProUGUI gt = GetComponent<TextMeshProUGUI>();
        gt.text = $"High Score: {score}";

        // Update the PlayerPrefs score if necessary
        if (score > PlayerPrefs.GetInt("HighScore"))
        {
            PlayerPrefs.SetInt("HighScore", score);
        }
    }
}
