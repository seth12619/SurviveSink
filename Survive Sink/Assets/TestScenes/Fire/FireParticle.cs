using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireParticle : DeleteSelf {
	float PI = 3.141592653589f;
	public float strength = 1.25f;

	// Use this for initialization
	void Start () {
		float theta = Random.Range(PI/4, PI/2);
		float phi = Random.Range(0, 2*PI);
		StartCoroutine(setSpeed( Mathf.Cos(phi) * Mathf.Cos(theta) * strength , 
			Mathf.Sin(theta) * strength * 2, Mathf.Sin(phi) * Mathf.Cos(theta) * strength));
	}
	
	IEnumerator setSpeed(float x, float y, float z){
		GetComponent<Rigidbody>().velocity = new Vector3(x, y, z);
		yield return null;
	}
}
