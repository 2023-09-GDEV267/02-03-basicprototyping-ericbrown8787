using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEditor;

public enum GameMode
{
    idle,
    playing,
    levelEnd
}

public class MissionDemolition : MonoBehaviour
{
    static private MissionDemolition S;

    [Header("Set in Inspector")]
    public TextMeshProUGUI uitLevel; // UIText_Level
    public TextMeshProUGUI uitShots; // UIText_Shots
    public TextMeshProUGUI uitButton; // UIButton_View text
    public Vector3 castlePos;
    public GameObject[] castles;

    [Header("Set Dynamically")]
    public int level; //Current Level
    public int levelMax; // Number of levels
    public int shotsTaken;
    public GameObject castle; //current castle
    public GameMode mode = GameMode.idle;
    public string showing = "Show Slingshot"; // Followcam mode
    void Start()
    {
        //Hardcoding gravity because I adjusted it for my mashup assignment
        Physics.gravity = new Vector3(0, -9.81f, 0);
        S = this;
        level = 0;
        levelMax = castles.Length;
        StartLevel();
    }
    void StartLevel()
    {

        //Get rid of the old castle if one exists
        if (castle!= null)
        {
            Destroy(castle);
        }
        //Destroy old projectiles if they exist
        GameObject[] gos = GameObject.FindGameObjectsWithTag("Projectile");
        foreach (GameObject pTemp in gos) {
            Destroy(pTemp);
        }

        //Instantiate the new castle
        castle = Instantiate<GameObject>(castles[level]);
        castle.transform.position = castlePos;
        shotsTaken= 0;

        //Reset the camera
        SwitchView("Show Both");
        ProjectileLine.S.Clear();

        //Reset the goal
        Goal.goalMet = false;
        UpdateGUI();

        mode = GameMode.playing;
    }
    
    void UpdateGUI()
    {
        // Show the data in the GUITexts
        uitLevel.text = $"Level: {level + 1} of {levelMax}";
        uitShots.text = $"Shots Taken: {shotsTaken}";
    }

    private void Update()
    {
        UpdateGUI();

        // Check level end
        if((mode == GameMode.playing) && Goal.goalMet)
        {
            // Change mode to stop checking for level end
            mode = GameMode.levelEnd;

            //Zoom out
            SwitchView("Show Both");
            // Start the next level in 2 seconds
            Invoke("NextLevel", 2f);
        }
    }

    void NextLevel()
    {
        level += 1;
        if (level == levelMax) {
            level = 0;
        }
        StartLevel();
    }

    public void SwitchView(string eView = "")
    {
        if (eView == "")
        {
            eView = uitButton.text;
        }
        showing = eView;

        switch (showing)
        {
            case "Show Slingshot":
                print("Show Slingshot");
                FollowCam.POI = null;
                uitButton.text = "Show Castle";
                break;

            case "Show Castle":
                FollowCam.POI = S.castle;
                uitButton.text = "Show Both";
                break;

            case "Show Both":
                FollowCam.POI = GameObject.Find("ViewBoth");
                uitButton.text = "Show Slingshot";
                break;
        }
    }
    //Static method to allow code anywhere to increment shotsTaken
    public static void ShotFired()
    {
        S.shotsTaken += 1;
    }
}

