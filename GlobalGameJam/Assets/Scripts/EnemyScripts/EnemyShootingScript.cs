using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShootingScript : MonoBehaviour {

    public GameObject BulletPrefab;

    private float RandomShoot;

    public AudioSource laserSound;

    void Start()
    {
        RandomTime();
    }

    void Update () {

        if (!Explosion.isDead)
        {
            if (RandomShoot >= 0)
            {
                RandomShoot -= Time.deltaTime;
            }

            var rot = transform.rotation;
            rot *= Quaternion.Euler(0, 90, 0);

            if (RandomShoot <= 0)
            {
                GameObject clone = Instantiate(BulletPrefab, transform.position, rot);
                clone.layer = 31;
                laserSound.pitch = Random.Range(0.9f, 1.1f);
                laserSound.Play();
                RandomTime();
            }
        }
	}

    void RandomTime() {
        RandomShoot = Random.Range(2, 5);
    }
}
