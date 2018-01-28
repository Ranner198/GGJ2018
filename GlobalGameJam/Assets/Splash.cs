using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Splash : MonoBehaviour {
    public RectTransform rt;
    public float startScale = 0.45f;
    public float endScale = 0.50f;
    public float timeLimit = 1.2f;
    private float timeTaken = 0;
    public Image image;
      

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        timeTaken += Time.deltaTime;
        if (timeTaken < 0.5f)
        {
            Color c = image.color;
            c.a = timeTaken * 2;
            image.color = c;
        }
        if (Input.anyKey || timeTaken >= timeLimit)
        {
            SceneManager.LoadScene("TitleScreen");
        }
        float v = (endScale - startScale) * (timeTaken / timeLimit) + startScale;
        rt.localScale = new Vector2(v, v);
    }
}
