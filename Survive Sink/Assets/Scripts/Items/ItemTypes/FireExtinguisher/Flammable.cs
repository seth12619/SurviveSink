using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flammable : MonoBehaviour {
	public GameObject ashes;
	public Fire[] fires;

	// Use this for initialization
	void Start () {
		fires = GetComponentsInChildren<Fire>(true);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	public IEnumerator burn(){
		Instantiate(ashes, transform.position, transform.rotation);
		Destroy(gameObject);
		yield return null;
	}
	
	public bool isOnFire(){
		foreach(Fire e in fires){
			if(e.onFire)
				return true;
		}
		return false;
	}
}
