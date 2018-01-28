using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MyLeaderboardScript : MonoBehaviour {

    dreamloLeaderBoard _MyLeaderBoard;

    public string _PlayerName = "";
    public int _Score = 0;
    public GUIStyle textStyle;

    private bool leaderboardHasLost = false;


    public enum GameState
    {
        waiting,
        running,
        ended,
        leaderboard
    }

    public static GameState gs;

    void Start()
    {
        this._MyLeaderBoard = dreamloLeaderBoard.GetSceneDreamloLeaderboard();

        gs = GameState.waiting;
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

        if (SceneControl.Refresh == true)
        {
            gs = GameState.leaderboard;
            SceneControl.Refresh = false;          
        }

    }

    void OnGUI()
    {
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
            List<dreamloLeaderBoard.Score> scoreList = _MyLeaderBoard.ToListHighToLow();

            _MyLeaderBoard.LoadScores();

            if (scoreList == null)
            {
                GUILayout.Label("(Loading...)");
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

                    GUILayout.BeginArea(new Rect((Screen.width-350) / 2, ((Screen.height - totalHeight)/2) + count * heightEach, 350, heightEach));                    
                    GUILayout.BeginHorizontal("box");
                    GUILayout.Label(count + ") ", textStyle, GUILayout.MinWidth(areaWidth * 0.2f));
                    GUILayout.Label(currentScore.playerName, textStyle, GUILayout.MinWidth(areaWidth * 0.5f));
                    GUILayout.Label(currentScore.score.ToString(), textStyle, GUILayout.MinWidth(areaWidth * 0.3f));  
                    GUILayout.EndHorizontal();
                    GUILayout.EndArea();

                    if (count >= maxToDisplay)
                        break;

                    print(currentScore.playerName);
                }


            }

            //gs = GameState.waiting;

        }
    }
}
