using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public int Level = 1;

    public static bool isKilled = false;

    private int LevelScore = 0, killed = 0;

    public static int TotalScore = 0;

    public Text LevelText, Score;

    public static bool hasLost = false;

    public AudioClip LevelUpSound;

    AudioSource audioSource;

    public ShieldRing shieldRing;
    public static bool spinning = false;

    void Start() {
        audioSource = GetComponent<AudioSource>();
        spinning = false;
    }

	void Update () {

        //Next Level
        if ((RayTrace.UploadPercentage >= 100) || (Input.GetKeyDown(KeyCode.L)))
        {
            Level++;
            RayTrace.UploadPercentage = 0;
            LevelText.text = "Level: " + Level.ToString();
            LevelUpdate();
            audioSource.PlayOneShot(LevelUpSound, 1.0f);
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
        shieldRing.Spin();
        LevelScore += (Level * 100);
    }

    public void Killednum()
    {
        killed += 100;
    }
}
