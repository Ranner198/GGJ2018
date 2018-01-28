using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldRing : MonoBehaviour {

    public float numSegments;
    public GameObject segmentPrefab;
    public float rotateSpeed;
    public float timeBetweenOpenings;
    private float timeTilOpen;

    // Use this for initialization
    void OnEnable()
    {
        CreateRing();
        timeTilOpen = timeBetweenOpenings;
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

    void OpenRandomShieldSegment()
    {
        int n = Random.Range(0, transform.childCount - 1);
        foreach(Transform child in transform)
        {
            if (n == 0)
            {
                child.GetComponent<ShieldSegment>().SetToOpening();
                break;
            }
            n--;
        }
    }

    // Update is called once per frame
    void Update()
    {
        timeTilOpen -= Time.deltaTime;
        if (timeTilOpen < 0.0f)
        {
            timeTilOpen = timeBetweenOpenings;
            // Trigger a new opening
            OpenRandomShieldSegment();
        }

        transform.position = new Vector3(0, 0, 0);
    }
}
