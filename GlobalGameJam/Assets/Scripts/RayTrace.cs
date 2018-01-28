using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class RayTrace : MonoBehaviour {

    public LayerMask LayerMask;

    public LineRenderer lr;

    public Transform Player;

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

        var fwd = -Player.right;

        Debug.DrawRay(transform.position, fwd * 200, Color.red);

        if (Physics.Raycast(transform.position, fwd, out hit, 200, LayerMask))
        {
            //print(hit.transform.gameObject.tag);
            if (hit.collider.gameObject.tag == "BigRing" && UploadPercentage < 100)
            {
                print("hit");
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

    }
}
