using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldSegment : MonoBehaviour {

    public ShieldRing ring;
    public GameObject colliderLeft;
    public GameObject colliderRight;
    public float openTime;
    public float closeTime;
    public float holdOpenTime;
    public float heldTime;
    public enum Mode
    {
        None,
        Opening,
        HeldOpen,
        Closing
    }
    public Mode mode;
    public float amountClosed = 1.0f;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        // Rotate the shield segment
        transform.rotation *= Quaternion.Euler(0, 0, ring.rotateSpeed * Time.deltaTime);

        // Update state
        float openSpeed = Time.deltaTime / openTime;
        float closeSpeed = Time.deltaTime / closeTime;
        switch (mode)
        {
            case Mode.None:
                break;
            case Mode.Opening:
                amountClosed -= openSpeed;
                if (amountClosed < 0.0f)
                {
                    mode = Mode.HeldOpen;
                    heldTime = holdOpenTime;
                    amountClosed = 0.0f;
                }
                break;
            case Mode.Closing:
                amountClosed += closeSpeed;
                if (amountClosed >= 1.0f)
                {
                    mode = Mode.None;
                    heldTime = holdOpenTime;
                    amountClosed = 1.0f;
                }
                break;
            case Mode.HeldOpen:
                heldTime -= Time.deltaTime;
                if (heldTime < 0.0f)
                {
                    heldTime = 0.0f;
                    mode = Mode.Closing;
                }
                break;
        }
        Vector3 v;
        v = colliderLeft.transform.localScale;
        v[0] = amountClosed;
        colliderLeft.transform.localScale = v;
        v = colliderRight.transform.localScale;
        v[0] = amountClosed;
        colliderRight.transform.localScale = v;
    }

    public void SetToOpening()
    {
        if (mode == Mode.None)
        {
            mode = Mode.Opening;
        }
    }
}
