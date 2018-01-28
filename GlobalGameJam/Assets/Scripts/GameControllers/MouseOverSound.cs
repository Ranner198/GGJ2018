using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseOverSound : MonoBehaviour {

    public AudioClip MouseOver, MouseClick;

    public AudioSource source;

    public bool Over;

    public void OnMouseEnter() {
        source.PlayOneShot(MouseOver);
    }

    public void OnMouseExit()
    {
        Over = false;
    }
}
