using UnityEngine;
using System.Collections;

public class WakeUpRigidbody : MonoBehaviour {
    Rigidbody rigidbody;

	// Use this for initialization
	void Start () {
		try {
        rigidbody = GetComponent<Rigidbody>();
		} catch(MissingComponentException e){
			//do nothing
		}
	}
	
	// Update is called once per frame
	void Update () {
		try {
        if (rigidbody.IsSleeping())
        {
            rigidbody.WakeUp();
        }
		} catch(MissingComponentException e) {
			//do nothing
		}
    }
}
