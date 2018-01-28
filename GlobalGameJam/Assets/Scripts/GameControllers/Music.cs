using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Music : MonoBehaviour {
    static Music instance = null;

	// Use this for initialization
	void Start () {
        if (instance == null)
            instance = this;
        if (instance != this)
        {
            DestroyObject(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
