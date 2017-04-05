using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaminaCounter : MonoBehaviour {
	public Material exhaust;
	public Material half;
	public Material full;

	// Use this for initialization
	void Start () {	
	PersistentTracker tracker = GameObject.Find("PersistentTrack").GetComponent<PersistentTracker>();
	int a = tracker.getStamina();
		if(a < 300) {
			this.GetComponent<Renderer>().material = exhaust;
		}
		if((a > 299) && (a < 701)) {
			this.GetComponent<Renderer>().material = half;
		}
		if(a > 700) {
			this.GetComponent<Renderer>().material = full;
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
