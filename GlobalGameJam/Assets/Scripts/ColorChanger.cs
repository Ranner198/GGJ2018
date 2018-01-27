using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChanger : MonoBehaviour {

    public Color White = new Color(0,0,0,0);
    public Color Red = Color.red;

    private Color _MyColor;

	void Update () {

        _MyColor = Color.Lerp(White, Red, Mathf.PingPong(Time.time, 1));

        GetComponent<MeshRenderer>().material.color = _MyColor;
	}
}
