﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {

    public GameObject Enemy;

	void Start () {
        InvokeRepeating("SpawnEnemies", 6, 6);
	}

    void SpawnEnemies()
    {
        Instantiate(Enemy, transform.position, transform.rotation);
    }
}