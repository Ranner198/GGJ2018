using UnityEngine;
using System.Collections.Generic;

public class LeaderBoardSample : MonoBehaviour {
	float startTime = 10.0f;
	float timeLeft = 0.0f;
	
	int totalScore = 0;
	string playerName = "";
	string code = "";

    dreamloLeaderBoard _MyLeaderBoard;

	enum gameState {
		waiting,
		running,
		enterscore,
        ended,
		leaderboard
	};
	
	gameState gs;
	
	
	// Reference to the dreamloLeaderboard prefab in the scene
	
	dreamloLeaderBoard dl;
	dreamloPromoCode pc;

	void Start () 
	{
		// get the reference here...
		this.dl = dreamloLeaderBoard.GetSceneDreamloLeaderboard();

		// get the other reference here
		this.pc = dreamloPromoCode.GetSceneDreamloPromoCode();

		this.timeLeft = startTime;
		this.gs = gameState.waiting;
	}

	void Update () 
	{
		if (this.gs == gameState.running)
		{
			timeLeft = Mathf.Clamp(timeLeft - Time.deltaTime, 0, this.startTime);
			if (timeLeft == 0)
			{
				this.gs = gameState.enterscore;
			}
		}
	}

    void OnGUI()
    {

        if (gs == gameState.ended)
        {
            playerName = PlayerPrefs.GetString("Name");
            totalScore = GameManager.Level;

            if (_MyLeaderBoard.publicCode == "") Debug.LogError("You forgot to set the public Code variable");
            if (_MyLeaderBoard.privateCode == "") Debug.LogError("You forgot to set the private Code variable");

            _MyLeaderBoard.AddScore(playerName, totalScore);

            print("Leaderboards");
            print(playerName + totalScore);
            gs = gameState.leaderboard;
        }

        if (gs == gameState.leaderboard)
        {
            GUILayout.Label("High Scores:");
            List<dreamloLeaderBoard.Score> scoreList = _MyLeaderBoard.ToListHighToLow();

            if (scoreList == null)
            {
                GUILayout.Label("(Loading...)");
            }
            else
            {
                int maxToDisplay = 15;
                int count = 0;
                foreach (dreamloLeaderBoard.Score currentScore in scoreList)
                {
                    count++;
                    GUILayout.BeginHorizontal();
                    GUILayout.Label(currentScore.playerName);
                    GUILayout.Label(currentScore.score.ToString());
                    GUILayout.EndHorizontal();

                    if (count >= maxToDisplay) break;
                }
            }
        }
    }
}
