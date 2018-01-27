﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPingAbility : MonoBehaviour {

    public GameObject Ring;

    public bool canPing = false;

    public float timer;

    private int count = 0;
    public int totalCount;

	void Update () {

        if (timer >= 0)
        {
            timer -= Time.deltaTime;
        }

        if (timer <= 0)
        {
            canPing = true;
        }

        if (Input.GetKeyDown(KeyCode.Space) && canPing == true)
        {
            StartCoroutine(Ping());
            canPing = false;
            timer = 3;
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