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
    public int damagePerBullet = 10;

    public Material _MyMaterial;
    public AudioSource soundExplode;

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
            soundExplode.Play();
            StartCoroutine(WaitToRestart());
        }
        
	}

    private void OnCollisionEnter(Collision coll)
    {
        if (coll.gameObject.layer == 31)
        {
            health -= damagePerBullet;
            if (health >= 0)
            {
                PlayerHealth.text = "Health :" + health.ToString();
            }
            StartCoroutine(Flash());
        }
    }

    IEnumerator WaitToRestart()
    {
        yield return new WaitForSeconds(4);
        GameManager.hasLost = false;
        isDead = false;
        SceneManager.LoadScene("TestScene");
    }

    IEnumerator Flash()
    {     
        //Call Flash
        int count = 4;

        for  (int i = 0; i < count; i++)
        {            
             _MyMaterial.SetColor("_Emission", Color.white);
            yield return new WaitForSeconds(.3f);
            _MyMaterial.SetColor("_Emission", Color.black);
            yield return new WaitForSeconds(.3f);
        }  
    }
}
