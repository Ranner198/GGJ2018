using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlightScript : MonoBehaviour {

    public Rigidbody rb;
    public float speed, maxSpeed = 10;

    public float MaxDistance;

    public Transform MainShip;

	void Start () {
        rb = GetComponent<Rigidbody>();
	}
	
	
	void Update () {

        //Input
        float X;
        float Y;

        X = Input.GetAxis("Horizontal");
        Y = Input.GetAxis("Vertical");

        //Movement System
        Vector2 Movement = new Vector2(X * speed, Y * speed);

        //Speed Control
        if (rb.velocity.magnitude < maxSpeed) {
            rb.AddForce(Movement);
        }

        //Vector2 _MainShipLoc = new Vector2(MainShip.transform.position.x, MainShip.transform.position.y);

        transform.LookAt(MainShip.transform.position, Vector3.back);

        //Distance from Ship
        Vector2 currentDistance = transform.position - MainShip.transform.position;

        print(currentDistance.magnitude);

        if (currentDistance.magnitude > MaxDistance)
        {
            rb.AddForce(-currentDistance * 10);
        }

	}
}
