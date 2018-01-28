using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldRing : MonoBehaviour {

    public float numSegments;
    public GameObject segmentPrefab;
    public float rotateSpeed;
    public float timeBetweenOpenings;
    private float timeTilOpen;

    private float switchTimer;
    public float spinTime = 0.5f;
    private float spinTimeTotal = 0.0f;
    private bool doSpin = false;
    private float spinX = 0;
    private float spinY = 0;
    public float speedSpinX = 3.0f;

    public float spinSpeedX = 3.0f;
    public float spinSpeedY = 1.5f;

    // Use this for initialization
    void OnEnable()
    {
        CreateRing();
        timeTilOpen = timeBetweenOpenings;
        spinX = 0;
        spinY = 0;
        doSpin = false;
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

        if (switchTimer >= 0)
        {
            switchTimer -= Time.deltaTime;
        }

        if (switchTimer <= 0)
        {
            Switch();
            rotateSpeed *= -1;
        }

        Debug.Log(doSpin);
        if (doSpin)
        {
            spinX += spinSpeedX;
            spinY += spinSpeedY;
            spinTimeTotal += Time.deltaTime;
            if (spinTimeTotal >= spinTime)
            {
                spinTimeTotal = 0;
                doSpin = false;
            }
        }
        else
        {
            if (spinX <= -spinSpeedX)
            {
                spinX += spinSpeedX;
            }
            else if (spinX >= spinSpeedX)
            {
                spinX -= spinSpeedX;
            }
            else
            {
                spinX = 0;
            }
            if (spinY <= -spinSpeedY)
            {
                spinY += spinSpeedY;
            }
            else if (spinY >= spinSpeedY)
            {
                spinY -= spinSpeedY;
            }
            else
            {
                spinY = 0;
            }
        }
        transform.rotation = Quaternion.Euler(spinX, spinY, 0);
    }

    public void Spin()
    {
        doSpin = true;
        spinSpeedX = Random.Range(6f, 12f);
        spinSpeedY = Random.Range(6f, 12f);
        spinTimeTotal = 0.0f;
    }

    void Switch()
    {
        switchTimer = Random.Range(7, 25);
    }
}
