using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MyLeaderboardScript : MonoBehaviour {

    dreamloLeaderBoard _MyLeaderBoard;

    public string _PlayerName = "";
    public int _Score = 0;

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

        _Score = GameManager.Level;

        if (GameManager.hasLost == true)
        {
            gs = GameState.ended;
            GameManager.hasLost = false;
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
        GUI.skin.label.fontSize = 20;

        if (gs == GameState.ended)
        {
            if (_MyLeaderBoard.publicCode == "") Debug.LogError("You forgot to set the public Code variable");
            if (_MyLeaderBoard.privateCode == "") Debug.LogError("You forgot to set the private Code variable");

            _MyLeaderBoard.AddScore(_PlayerName, _Score);

            print("Leaderboards");
            print(_PlayerName + _Score);
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
                int maxToDisplay = 15;
                int count = 0;

                GUILayout.Label("High Scores:");


                foreach (dreamloLeaderBoard.Score currentScore in scoreList)
                {
                    count++;

                    GUILayout.BeginArea(new Rect((Screen.width / 2) - 200, (Screen.height / 2) + count * 40, 250, 30));                    
                    GUILayout.BeginHorizontal("box");
                    GUILayout.Label(count + ") ");
                    GUILayout.Label(currentScore.playerName);
                    GUILayout.Label(currentScore.score.ToString());                  
                    GUILayout.EndHorizontal();
                    GUILayout.EndArea();

                    if (count >= maxToDisplay) break;

                    print(currentScore.playerName);
                }

                
            }

            //gs = GameState.waiting;

        }
    }
}
