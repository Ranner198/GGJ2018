using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {

    public GameObject Enemy;
    public float shootTimeMin;
    public float shootTimeMax;
    public float shootTime;
    public float geometricAvg = 0.9f;
    public Animator anim;
    public float lastSpeed = 1.0f;
    public float timeUpdate = 0.0f;

    private float timeToShoot;

	void Start () {
        InvokeRepeating("SpawnEnemies", 6, 6);
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

    private void Update()
    {
        float targetSpeed = anim.speed;

        shootTime -= Time.deltaTime;
        if (shootTime <= 0)
        {
            // Time out!
            ResetShootTimer();
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
        timeUpdate += Time.deltaTime;
        lastSpeed = anim.speed;
        while (timeUpdate > 0.1f) {
            lastSpeed = lastSpeed * geometricAvg + targetSpeed * (1-geometricAvg);
            timeUpdate -= 0.1f;
        }
        anim.speed = lastSpeed;
    }
}
