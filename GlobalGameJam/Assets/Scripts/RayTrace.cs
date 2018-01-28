using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class RayTrace : MonoBehaviour {

    public LayerMask LayerMask;

    public LineRenderer lr;

    public Text Upload;
    public static float UploadPercentage;

    public ParticleSystem PS;

    void Start()
    {
        //Default
        Upload.text = "Upload: " + Mathf.RoundToInt(UploadPercentage).ToString() + "%";

        PS.enableEmission = false;
    }

	void Update () {
               
        RaycastHit hit;

        var fwd = Vector2.left;

        Debug.DrawRay(transform.position, fwd * 20, Color.red);

        if (Physics.Raycast(transform.position, fwd, out hit, 20, LayerMask))
        {
            
            if (hit.collider.gameObject.tag == "BigRing" && UploadPercentage < 100)
            {
                lr.SetPosition(0, transform.position);
                lr.enabled = true;
                UploadPercentage += .25f;

                Upload.text = "Upload: " + Mathf.RoundToInt(UploadPercentage).ToString() + "%";

                PS.enableEmission = true;
            }
            else
            {
                lr.enabled = false;
                PS.enableEmission = false;
            }
        }

        lr.SetPosition(0, transform.position);
        lr.enabled = true;
    }
}
