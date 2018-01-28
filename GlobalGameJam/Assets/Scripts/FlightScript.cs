using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlightScript : MonoBehaviour {

    public Rigidbody rb;
    public float speed, maxSpeed = 10;

    public float MaxDistance;

    public Transform MainShip;

    public float offset;

	void Start () {
        //rigidbody
        rb = GetComponent<Rigidbody>();

        //show mouse cursor
        Cursor.visible = true;
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

        //Look at ship
        //transform.LookAt(MainShip.transform.position, Vector3.back);

        //Face Towards MousePoint
        //var mousePos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.nearClipPlane);

        //var mousePosition = Camera.main.ScreenToWorldPoint(mousePos);
    
        //print(mousePosition);

        var PlayerPosition = Camera.main.WorldToScreenPoint(transform.position);
        Vector3 Dir = (PlayerPosition - Input.mousePosition).normalized;
        transform.rotation = Quaternion.Euler (0,0, Mathf.Atan2(Dir.y, Dir.x) * Mathf.Rad2Deg + offset);

        //Distance from Ship
        Vector2 currentDistance = transform.position - MainShip.transform.position;

        if (currentDistance.magnitude > MaxDistance)
        {
            rb.AddForce(-currentDistance * 10);
        }

	}

    void OnMouseEnter()
    {
        //Cursor.SetCursor(cur)
    }
}
