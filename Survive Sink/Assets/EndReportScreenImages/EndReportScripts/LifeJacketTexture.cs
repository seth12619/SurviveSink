using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeJacketTexture : MonoBehaviour {
	public Material withLifeVest;
	public Material noLifeVest;

	// Use this for initialization
	void Start () {	
	PersistentTracker tracker = GameObject.Find("PersistentTrack").GetComponent<PersistentTracker>();
		if(tracker.getLifeJacketTracker() > 0) {
			this.GetComponent<Renderer>().material = withLifeVest;
		}
		if(tracker.getLifeJacketTracker() < 1) {
			this.GetComponent<Renderer>().material = noLifeVest;
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
