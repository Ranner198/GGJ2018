using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RingController : MonoBehaviour {

    public float speed, scaleSpeed, DestroyTime;

	void Start () {
        Destroy(gameObject, DestroyTime);
	}
	
	
	void Update () {
        var current = transform.localScale;
        Vector3 SizeScale = new Vector3(scaleSpeed, scaleSpeed, scaleSpeed);
        current += SizeScale;
        transform.localScale = current;

        transform.Translate(Vector3.back * speed * Time.deltaTime);
	}
}
