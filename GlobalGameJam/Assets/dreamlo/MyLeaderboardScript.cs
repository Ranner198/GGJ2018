using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;


public class MyLeaderboardScript : MonoBehaviour {

    dreamloLeaderBoard _MyLeaderBoard;

    public string _PlayerName = "";
    public int _Score = 0;
    public GUIStyle textStyle;

    public List<dreamloLeaderBoard.Score> scoreList;

    private bool leaderboardHasLost = false;
    private bool RefreshLeaderboard = false;

    public enum GameState
    {
        waiting,
        LoadScores,
        ended,
        leaderboard

    }

    public static GameState gs;

    void Start()
    {
        this._MyLeaderBoard = dreamloLeaderBoard.GetSceneDreamloLeaderboard();

        _MyLeaderBoard.LoadScores();
        if (Application.loadedLevel == 5)
        {
            gs = GameState.leaderboard;
        }

        if (Application.loadedLevel == 2)
        {
            gs = GameState.waiting;
        }
     
    }

    void Update()
    {
        _PlayerName = PlayerPrefs.GetString("Name");

        _Score = GameManager.TotalScore;

        if (GameManager.hasLost == true && !leaderboardHasLost)
        {
            gs = GameState.ended;
            leaderboardHasLost = true;
        }

        if (SceneControl.Refresh == true && !RefreshLeaderboard)
        {
            gs = GameState.leaderboard;
            SceneControl.Refresh = false;
            RefreshLeaderboard = true;           
        }

    }

    void OnGUI()
    {
        scoreList = _MyLeaderBoard.ToListHighToLow();

        //Font Size
        GUI.skin.label.fontSize = 48;

        if (gs == GameState.ended)
        {
            if (_MyLeaderBoard.publicCode == "") Debug.LogError("You forgot to set the public Code variable");
            if (_MyLeaderBoard.privateCode == "") Debug.LogError("You forgot to set the private Code variable");

            _MyLeaderBoard.AddScore(_PlayerName, _Score);

            gs = GameState.waiting;
        }

        if (gs == GameState.leaderboard)
        {          
            if (scoreList == null)
            {
                GUILayout.Label("(Loading...)");
                //gs = GameState.waiting;
            }
            else
            {
                int maxToDisplay = 10;
                int count = 0;

                float totalHeight = Screen.height * 0.66f;
                float heightEach = totalHeight / maxToDisplay;
                textStyle.fontSize = (int)(heightEach * 0.6f);
                float areaWidth = 350;

                foreach (dreamloLeaderBoard.Score currentScore in scoreList)
                {
                    count++;

                    GUILayout.BeginArea(new Rect((Screen.width - 350) / 2, ((Screen.height - totalHeight) / 2) + count * heightEach, 350, heightEach));
                    GUILayout.BeginHorizontal("box");
                    GUILayout.Label(count + ") ", textStyle, GUILayout.MinWidth(areaWidth * 0.2f));
                    GUILayout.Label(currentScore.playerName, textStyle, GUILayout.MinWidth(areaWidth * 0.5f));
                    GUILayout.Label(currentScore.score.ToString(), textStyle, GUILayout.MinWidth(areaWidth * 0.3f));
                    GUILayout.EndHorizontal();
                    GUILayout.EndArea();

                    if (count >= maxToDisplay)
                        break;
                }
            }             
            
        }


    }
}
