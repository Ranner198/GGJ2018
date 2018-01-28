using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollower : MonoBehaviour {
    public Transform PlayerLocation;
    public Transform MotherShipLocation;
    public float percentAwayFromMother;

    private Quaternion originalRotation;
    private Vector3 originalLocation;
    private Vector3 originalDirection;
    private Vector3 middleLookAt;

	// Use this for initialization
	void Start () {
        originalLocation = transform.position;
        originalRotation = transform.rotation;
        originalDirection = transform.forward;
        Vector3 v = originalLocation - MotherShipLocation.position;
        float d = v.magnitude;
        middleLookAt = transform.position + originalDirection * d;
    }
	
	// Update is called once per frame
	void Update () {
        Vector3 diff = MotherShipLocation.position - PlayerLocation.position;
        Vector3 mid = diff * percentAwayFromMother + middleLookAt;

        //transform.LookAt(mid);
        transform.position = originalLocation - mid;

    }
}
