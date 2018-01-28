using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Explosion : MonoBehaviour {

    public Rigidbody rb;

    public int health = 100;

    public static bool isDead = false; 

    public float force;

    public Renderer Player;

    public ParticleSystem PS;

    public Text PlayerHealth;

    void Start()
    {
        PS.enableEmission = false;
    }

    void Update () {

        if (health <= 0)
        {
            Player.enabled = false;
            PS.enableEmission = true;
            GameManager.hasLost = true;
            isDead = true;     
        }
	}

    private void OnCollisionEnter(Collision coll)
    {
        if (coll.gameObject.layer == 31)
        {
            health -= 25;
            PlayerHealth.text = "Health :" + health.ToString(); ;
        }
    }
}
