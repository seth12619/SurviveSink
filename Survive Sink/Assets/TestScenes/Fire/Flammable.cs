using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flammable : MonoBehaviour {
	public GameObject ashes;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	public IEnumerator burn(){
		Instantiate(ashes, transform.position, transform.rotation);
		Destroy(gameObject);
		yield return null;
	}
}
