using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMovementScript : MonoBehaviour {

    public float speed;

	void Update () {
        transform.Translate(Vector2.left * speed * Time.deltaTime);
	}

    void OnCollisionEnter(Collision coll)
    {
        Debug.Log("Hit " + coll.gameObject);
        if (coll.gameObject.tag == "Player")
        {
            Destroy(gameObject);
        }
        if (coll.gameObject.tag == "Enemy")
        {
            Destroy(gameObject);
        }
        if (coll.gameObject.tag == "ShieldSegment")
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "ShieldSegment")
        {
            Destroy(gameObject);
        }
    }
}
