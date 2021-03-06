﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFlightScript : MonoBehaviour {

    public Rigidbody rb;

    public Transform Player;

    public float Speed;

    public GameObject PS;

	void Start () {
        Player = GameObject.FindGameObjectWithTag("Player").transform;
	}


    void LateUpdate() {

        if (!Explosion.isDead)
        {

            float _distance = (transform.position - Player.transform.position).magnitude;

            //Vector3 Direction = (transform.position - Player.transform.position).normalized;

            if (_distance > 3)
            {
                //transform.position = Vector3.MoveTowards(transform.position, Player.transform.position, Speed);
                Vector3 Movement = Vector3.forward * Speed;
                rb.AddRelativeForce(Movement);
            }

            if (_distance < 3)
            {
                if (rb.velocity.x > 0 || rb.velocity.y > 0)
                {
                    rb.velocity = new Vector3(0, 0, 0);
                }
            }

            transform.LookAt(Player.position, Vector3.back);
        }
    }

    void OnCollisionEnter(Collision coll)
    {
        if (coll.gameObject.tag == "Bullet")
        {
            GameManager.isKilled = true;
            //Call Explosion
            Instantiate(PS, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
