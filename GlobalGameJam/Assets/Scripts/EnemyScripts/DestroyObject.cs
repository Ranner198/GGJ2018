using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObject : MonoBehaviour {

    public AudioClip ExplosionSoundEffect;

    public AudioSource source;

    void Start () {
        Invoke("Suicide", 3.0f);
	}

    void Suicide()
    {
        source.PlayOneShot(ExplosionSoundEffect);
        Destroy(gameObject);
    }
}
