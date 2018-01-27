using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneControl : MonoBehaviour {
    public void OnPlay()
    {
        SceneManager.LoadScene("TestScene");
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
}
