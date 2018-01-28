using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public int Level = 1;

    public static bool isKilled = false;

    private int LevelScore = 0, killed = 0;

    public static int TotalScore;

    public Text LevelText, Score;

    public static bool hasLost = false;

	void Update () {

        //Next Level
        if (RayTrace.UploadPercentage >= 100)
        {
            Level++;
            RayTrace.UploadPercentage = 0;
            LevelText.text = "Level: " + Level.ToString();
            LevelUpdate();
        }

        if (isKilled)
        {
            Killednum();
            isKilled = false;
        }

        TotalScore = killed + LevelScore;

        Score.text = "Score: " + TotalScore.ToString();
	}

    void LevelUpdate()
    {
        LevelScore += (Level * 100);
    }

    public void Killednum()
    {
        killed += 100;
    }
}
