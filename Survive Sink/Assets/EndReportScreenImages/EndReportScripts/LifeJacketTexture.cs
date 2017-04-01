using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeJacketTexture : MonoBehaviour {
	private static GameObject pt = null;
	private PersistentTracker tracker = pt.GetComponent<PersistentTracker>();
	
	public Material withLifeVest;
	public Material noLifeVest;

	// Use this for initialization
	void Start () {	
		pt = GameObject.Find("PersistentTrack");
		if(tracker.getLifeJacketTracker() > 0) {
			this.GetComponent<Renderer>().material = withLifeVest;
		}
		if(tracker.getLifeJacketTracker() < 0) {
			this.GetComponent<Renderer>().material = noLifeVest;
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
