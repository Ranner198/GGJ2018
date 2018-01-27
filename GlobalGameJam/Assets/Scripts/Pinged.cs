using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pinged : MonoBehaviour {

    public GameObject Collider_Left, Collider_Right;

    private Renderer Left, Right;

    public bool isVisible = false;
    public float timer;

    void Start () {
        /*
        left = gameObject.GetComponent<BoxCollider>();
        right = gameObject.GetComponent<BoxCollider>();
        */

        Left = Collider_Left.GetComponent<Renderer>();
        Left.enabled = false;

        Right = Collider_Right.GetComponent<Renderer>();
        Right.enabled = false;
    }
	
	
	void Update () {
	
        if (timer >= 0)
        {
            timer -= Time.deltaTime;
        }
       
        if (timer <= 0)
        {
            isVisible = false;
        }

        if (isVisible == true)
        {
            Left.enabled = true;
            Right.enabled = true;
        }
        else
        {
            Left.enabled = false;
            Right.enabled = false;
        }
    }

    void OnTriggerEnter(Collider coll)
    {       
        if (coll.gameObject.tag == ("Ring"))
        {
            timer = 1.5f;
            isVisible = true;
        }
    }
}
