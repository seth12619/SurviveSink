using UnityEngine;
using System.Collections;

public class HitBehavior : MonoBehaviour {

	PlayerGrit grit;
	Rigidbody rg;
	// Use this for initialization
	void Start () {
		rg = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void Awake(){
		grit = GetComponent<PlayerGrit> ();
	}

	void OnCollisionEnter(Collision other){
		Vec3 velocity = rg.velocity;
		
		if (other.gameObject.tag == "Debris") {
			Debug.Log ("COLLIDING WITH SOMETHING!");
			grit.takeDamage (rg.mass/100);
		}
	}

}
