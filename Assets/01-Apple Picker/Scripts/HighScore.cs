using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; // Instead of UnityEngine.UI

public class HighScore : MonoBehaviour
{
    public static int score = 1000;

    // Update is called once per frame
    void Update()
    {
        TextMeshProUGUI gt = GetComponent<TextMeshProUGUI>();
        gt.text = $"High Score: {score}";
    }
}
