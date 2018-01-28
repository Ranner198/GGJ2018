using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleScreenControl : MonoBehaviour {

	void Update() {
        if (Input.GetKey(KeyCode.Escape))
            SceneManager.LoadScene("TitleScreen");
    }
}
