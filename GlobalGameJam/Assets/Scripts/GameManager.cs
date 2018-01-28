using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public static int Level = 1;

    public Text LevelText;

    public static bool hasLost = false;

	void Update () {

        //Next Level
        if (RayTrace.UploadPercentage >= 100)
        {
            Level++;
            RayTrace.UploadPercentage = 0;
            LevelText.text = "Level: " + Level.ToString();
        }
        if (Input.GetKey(KeyCode.P))
        {
            hasLost = true;
        }

	}
}
