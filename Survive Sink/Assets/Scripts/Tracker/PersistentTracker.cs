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
	
	public bool water() {
		return mainTrScript.didJump();
	}
	
	public int getLifeJacketTracker() {
		return mainTrScript.getLifeJacketTracker();
	}
	
	public int getTime() {
		return mainTrScript.getTime();
	}
	
	public int getHealth() {
		return mainTrScript.getHealth();
	}
	
	public int getStamina() {
		return mainTrScript.staminaNo();
	}
	
	public int getScore() {
		return mainTrScript.getScore();
	} 
}
