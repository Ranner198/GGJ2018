using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour {

    public Rigidbody rb;

    public int health = 100;

    public float force;

    public Renderer Player;

    public ParticleSystem PS;

    void Start()
    {
        PS.enableEmission = false;
    }

    void FixedUpdate () {

        if (health <= 0)
        {
            Player.enabled = false;
            PS.enableEmission = true;
            GameManager.hasLost = true;           
        }
	}

    private void OnCollisionEnter(Collision coll)
    {
        if (gameObject.tag == "Bullet")
        {
            health -= 25;
        }
    }
}
