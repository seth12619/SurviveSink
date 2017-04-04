using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GradeCounter : MonoBehaviour {
	public Material F;
	public Material D;
	public Material C;
	public Material B;
	public Material A;
	public Material ded;
	
	// Use this for initialization
	void Start () {	
	PersistentTracker tracker = GameObject.Find("PersistentTrack").GetComponent<PersistentTracker>();
	int a = tracker.getScore();
	if ((tracker.water() && (tracker.getLifeJacketTracker() > 0)) || !tracker.water()) {
		if(a < 1000) {
			this.GetComponent<Renderer>().material = F;
		}
		if((a > 999) && (a < 1500)) {
			this.GetComponent<Renderer>().material = D;
		}
		if((a > 1499) && (a < 2000)) {
			this.GetComponent<Renderer>().material = C;
		}
		if((a > 1999) && (a < 2500)) {
			this.GetComponent<Renderer>().material = B;
		}
		if(a > 2499) {
			this.GetComponent<Renderer>().material = A;
		}
	} else {
		this.GetComponent<Renderer>().material = ded;
	}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
