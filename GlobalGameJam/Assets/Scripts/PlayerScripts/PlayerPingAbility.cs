using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPingAbility : MonoBehaviour {

    public GameObject Ring;

    public bool canPing = false;

    public float timer;

    public BoxCollider ConeTrigger;

    private int count = 0;
    public int totalCount;
    public AudioSource soundScan;

    void Start()
    {
        ConeTrigger = GetComponent<BoxCollider>();
        ConeTrigger.enabled = false;
    }

    void Update () {

        if (!Explosion.isDead)
        {
            if (timer >= 0)
            {
                timer -= Time.deltaTime;
            }

            if (timer <= 0)
            {
                canPing = true;
            }

            if (timer <= 1.5f)
                ConeTrigger.enabled = false;

            if (Input.GetMouseButtonDown(1))
            {
                if (canPing == true)
                {
                    //ConeTrigger.enabled = true; // disabled for moment
                    StartCoroutine(Ping());
                    soundScan.Play();
                    canPing = false;
                    timer = 2.25f;
                }
            }
        }
	}

    IEnumerator Ping()
    {    
        for (count = 0; count < totalCount; count++)
        {          
            Quaternion rot = Quaternion.Euler(transform.rotation.x, transform.rotation.y + 90, transform.rotation.z);
            GameObject Clone = Instantiate(Ring, transform.position, rot);
            Clone.transform.rotation = transform.rotation * Quaternion.Euler(0, 180, 0);
            yield return new WaitForSeconds(.2f);
        }
    }
}
