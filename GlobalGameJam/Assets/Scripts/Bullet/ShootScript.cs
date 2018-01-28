using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootScript : MonoBehaviour {

    public float timer;

    private float shootTimer;

    public bool canShoot;

    public GameObject BulletPrefab;

    public Transform[] CannonLoc;

    public AudioSource laserSound;

    private int index;
    private int i;

	void Update () {
		if (shootTimer >= 0)
        {
            shootTimer -= Time.deltaTime;
        }

        if (shootTimer <= 0)
        {
            canShoot = true;
        }

        if (shootTimer <= 0 && canShoot)
        {
            if (Input.GetMouseButtonDown(0))
            {
                index++;
                if (index % 2 == 0)
                    i = 1;
                else
                    i = 0;
                GameObject Clone = Instantiate(BulletPrefab,  new Vector3 (CannonLoc[i].transform.position.x, CannonLoc[i].transform.position.y, 0), transform.rotation);
                Clone.layer = 30;
                canShoot = false;
                shootTimer = timer;
                laserSound.pitch = Random.Range(0.9f, 1.1f);
                laserSound.Play();
            }
        }
	}
}
