using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlightScript : MonoBehaviour {

    public Rigidbody rb;
    public float speed, rotSpeed;

	void Start () {
        rb = GetComponent<Rigidbody>();
	}
	
	
	void Update () {
        float X;
        float Y;

        X = Input.GetAxis("Horizontal");
        Y = Input.GetAxis("Vertical");

        Vector2 Vec2 = new Vector2(X * speed, Y * speed);

        rb.velocity = Vec2 * Time.deltaTime;
	}
}
