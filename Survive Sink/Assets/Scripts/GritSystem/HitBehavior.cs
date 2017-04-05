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
	//	Vec3 velocity = rg.velocity;
		
		if (other.gameObject.tag == "Debris" || other.gameObject.tag == "Furniture") {
			grit.gotHit(other.gameObject);
		}
	}
    
    void OnTriggerEnter(Collider other)
    {
		Debug.Log("TRIGGER");
        if(other.gameObject.tag == "Fire")
        {
            grit.fire();
        }
		else if(other.gameObject.tag == "InstaDeath") {
			Debug.Log("I SHOULD DIE NOW");
			GameObject.Find("Tracker").GetComponent<MainTracker>().hasJumped();
			grit.death();
		}
    }
}
