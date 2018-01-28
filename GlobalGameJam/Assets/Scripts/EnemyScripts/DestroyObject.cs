using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObject : MonoBehaviour {

	void Start () {
        Invoke("Suicide", 3.0f);
	}

    void Suicide()
    {
        Destroy(gameObject);
    }
}
