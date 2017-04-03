using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersistentTracker : MonoBehaviour {
	MainTracker mainTrScript = null;

	// Use this for initialization
	void Start () {

		mainTrScript = GameObject.Find("Tracker").GetComponent<MainTracker>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	public int getLifeJacketTracker() {
		return mainTrScript.getLifeJacketTracker();
	}
}
