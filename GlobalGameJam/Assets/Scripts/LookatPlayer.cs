using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookatPlayer : MonoBehaviour {

    public Transform Player;
    public float speed;

	void Start () {
        Player = GameObject.FindGameObjectWithTag("Player").transform;
    }

	void Update () {

        transform.LookAt(Player.position, Vector3.back);

    }
}
