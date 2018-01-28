using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShootingScript : MonoBehaviour {

    public GameObject BulletPrefab;

    private float RandomShoot;

	void Update () {

        if (RandomShoot >= 0)
        {
            RandomShoot -= Time.deltaTime;
        }

        var rot = transform.rotation;
        rot *= Quaternion.Euler(0,90,0);

        if (RandomShoot <= 0)
        {
            GameObject clone = Instantiate(BulletPrefab, transform.position, rot);
            clone.layer = 31;
            RandomTime();
        }
         
	}

    void RandomTime() {
        RandomShoot = Random.Range(2, 5);
    }
}
