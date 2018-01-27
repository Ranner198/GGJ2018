using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFlightScript : MonoBehaviour {

    public Rigidbody rb;

    public Transform Player;

	void Start () {
        Player = GameObject.FindGameObjectWithTag("Player").transform;
	}


    void Update() {
        float _distance = (transform.position - Player.transform.position).magnitude;

        if (_distance > 3)
        {
            transform.position = Vector3.MoveTowards(transform.position, Player.transform.position, .05f);
        }

        //transform.LookAt(Player.transform.position, Vector2.up);
    }
}
