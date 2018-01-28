using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneControl : MonoBehaviour {

    public InputField Name;
    public Text PlaceHolder;
    public string _Name;
    public static bool Refresh = false;

    public void OnPlay()
    {
        _Name = Name.text;

        if (_Name != "")
        {
            PlayerPrefs.SetString("Name", _Name);
            SceneManager.LoadScene("TestScene");
        }
        else
        {
            PlaceHolder.text = "*Name Required*";
            PlaceHolder.color = Color.red;
        }
    }

    public void OnCredits()
    {
        SceneManager.LoadScene("CreditsScreen");
    }

    public void OnSettings()
    {
        SceneManager.LoadScene("SettingsScreen");
    }

    public void GoTitleScreen()
    {
        SceneManager.LoadScene("TitleScreen");
    }

    public void Leaderboard()
    {
        SceneManager.LoadScene(4);
        Refresh = true;
    }
}
