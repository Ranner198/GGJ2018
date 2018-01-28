using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {

    public GameObject Enemy;
    public float shootTimeMin;
    public float shootTimeMax;
    public float shootTime = 10.0f;
    public float geometricAvg = 0.9f;
    public Animator anim;
    public float lastSpeed = 1.0f;
    public float timeUpdate = 0.0f;
    public int numberShotsInRing = 15;
    public GameObject bulletPrefab;
    public float startDistance = 1.0f;

	void Start () {
        InvokeRepeating("SpawnEnemies", 6, 6);
        shootTime = 20.0f;
	}

    void ResetShootTimer()
    {
        shootTime = Random.Range(shootTimeMin, shootTimeMax);
    }

    void SpawnEnemies()
    {
        if (!Explosion.isDead)
        {
            Instantiate(Enemy, transform.position, transform.rotation);
        }
    }

    private void ShootEverywhere()
    {
        float anglePer = 360.0f/numberShotsInRing;
        for (float angle=0; angle<360.0; angle += anglePer)
        {
            GameObject clone = Instantiate(bulletPrefab, transform.position, Quaternion.Euler(0, 0, angle));
            clone.layer = 31;
        }
    }

    private void Update()
    {
        float targetSpeed = anim.speed;
        float delta = Time.deltaTime;
        if (delta > 0.5f)
            delta = 0.5f;

        shootTime -= delta;
        if (shootTime <= 0)
        {
            // Time out!
            ResetShootTimer();

            // Spawn a bunch of laser shots
            ShootEverywhere();
        }

        if (shootTime < 3.0f)
        {
            if (shootTime < 1.0f)
            {
                targetSpeed = 10.0f;
            } else
            {
                targetSpeed = 3.0f / shootTime;
            }
        } else
        {
            targetSpeed = 1.0f;
        }
        timeUpdate += delta;
        lastSpeed = anim.speed;
        while (timeUpdate > 0.1f) {
            lastSpeed = lastSpeed * geometricAvg + targetSpeed * (1-geometricAvg);
            timeUpdate -= 0.1f;
        }
        anim.speed = lastSpeed;
    }
}
