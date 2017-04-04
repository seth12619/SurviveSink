using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthCounter : MonoBehaviour {
	public Material ded;
	public Material ten;
	public Material twentyFive;
	public Material fifty;
	public Material seventyFive;
	public Material full;

	// Use this for initialization
	void Start () {	
	PersistentTracker tracker = GameObject.Find("PersistentTrack").GetComponent<PersistentTracker>();
	int a = tracker.getStamina();
	if ((tracker.water() && (tracker.getLifeJacketTracker() > 0)) || !tracker.water()) {
		if(a < 1) {
			this.GetComponent<Renderer>().material = ded;
		}
		if((a > 0) && (a < 11)) {
			this.GetComponent<Renderer>().material = ten;
		}
		if((a > 10) && (a < 26)) {
			this.GetComponent<Renderer>().material = twentyFive;
		}
		if((a > 25) && (a < 51)) {
			this.GetComponent<Renderer>().material = fifty;
		}
		if((a > 50) && (a < 76)) {
			this.GetComponent<Renderer>().material = seventyFive;
		}
		if(a > 99) {
			this.GetComponent<Renderer>().material = full;
		}
	} else {
		this.GetComponent<Renderer>().material = ded;
	}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
