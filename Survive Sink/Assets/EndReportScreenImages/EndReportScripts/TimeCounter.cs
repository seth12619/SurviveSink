using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeCounter : MonoBehaviour {
	public Material slow;
	public Material average;
	public Material fast;

	// Use this for initialization
	void Start () {	
	PersistentTracker tracker = GameObject.Find("PersistentTrack").GetComponent<PersistentTracker>();
	int a = tracker.getTime();
		if(a < 150) {
			this.GetComponent<Renderer>().material = fast;
		}
		if((a > 149) && (a < 600)) {
			this.GetComponent<Renderer>().material = average;
		}
		if(a > 599) {
			this.GetComponent<Renderer>().material = slow;
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
