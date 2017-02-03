using UnityEngine;
using System.Collections;

public class HitBehavior : MonoBehaviour {

	PlayerGrit grit;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void Awake(){
		grit = GetComponent<PlayerGrit> ();
	}

	void OnCollisionEnter(Collision other){
		if (other.gameObject.tag == "Debris") {
			Debug.Log ("COLLIDING WITH SOMETHING!");
			grit.takeDamage (3);
		}
	}

}
