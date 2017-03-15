using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoamBall : DeleteSelf {
    public float speed = 10f;

	// Use this for initialization
	void Start () {
        Transform moveTo = GameObject.FindGameObjectWithTag("Target").transform;

        GetComponent<Rigidbody>().velocity = (moveTo.position - transform.position) * speed;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Fire")
        {
            Fire x = other.gameObject.GetComponent<Fire>();
            StartCoroutine(x.stopFire());
        }else if(other.gameObject.tag == "FireParticle")
        {
            Destroy(other.gameObject);
        }
    }
}
