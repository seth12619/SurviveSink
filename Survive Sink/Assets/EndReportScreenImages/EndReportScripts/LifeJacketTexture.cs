using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeJacketTexture : MonoBehaviour {
	public Material withLifeVest;
	public Material noLifeVest;
	PersistentTracker tracker;

	// Use this for initialization
	void Start () {	
	tracker = GameObject.Find("PersistentTrack").GetComponent<PersistentTracker>();
		if(tracker.getLifeJacketTracker() > 0) {
			this.GetComponent<Renderer>().material = withLifeVest;
		} else {
			this.GetComponent<Renderer>().material = noLifeVest;
		}
	}
	float delay = 0;
	// Update is called once per frame
	void Update () {
		if (delay > 5.0f) {
		if(tracker.getLifeJacketTracker() > 0) {
			this.GetComponent<Renderer>().material = withLifeVest;
		} else {
			this.GetComponent<Renderer>().material = noLifeVest;
		}
		delay  += Time.deltaTime;
		} else {
			//do nothing
		}	
	}
}
