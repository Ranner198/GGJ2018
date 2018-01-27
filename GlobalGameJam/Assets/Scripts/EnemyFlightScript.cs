using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFlightScript : MonoBehaviour {

    public Rigidbody rb;

    private Vector3 distance;

    public Transform Player;

	void Start () {
        Player = GameObject.FindGameObjectWithTag("Player").transform;
	}


    void Update() {
        float _distance = (transform.position - Player.transform.position).magnitude;

        print(_distance);
        if (_distance > 3)
        {
            transform.position = Vector3.MoveTowards(transform.position, Player.transform.position, .1f);
        }
    }
}
