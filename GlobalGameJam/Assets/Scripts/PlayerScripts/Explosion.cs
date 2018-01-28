using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
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

        if ((health <= 0) && !GameManager.hasLost || Input.GetKeyDown(KeyCode.I))
        {
            PS.Play();
            Player.enabled = false;
            //PS.Stop();
            PS.enableEmission = true;
            GameManager.hasLost = true;
            isDead = true;
            StartCoroutine(WaitToRestart());
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

    IEnumerator WaitToRestart()
    {
        yield return new WaitForSeconds(4);
        GameManager.hasLost = false;
        Application.LoadLevel(Application.loadedLevel);
    }
}
