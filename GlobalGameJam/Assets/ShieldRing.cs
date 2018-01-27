using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldRing : MonoBehaviour {
    public float numSegments;
    public GameObject segmentPrefab;
    public float rotateSpeed;

    // Use this for initialization
    void OnEnable()
    {
        CreateRing();
    }

    void CreateRing()
    {
        float deltaAngle = 360.0f / numSegments;
        float angle = 0.0f;

        for (int i = 0; i < numSegments; i++, angle += deltaAngle)
        {
            GameObject segment = (GameObject)Instantiate(segmentPrefab, gameObject.transform);
            segment.GetComponent<ShieldSegment>().ring = this;
            segment.transform.rotation = Quaternion.Euler(0, 0, angle);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
