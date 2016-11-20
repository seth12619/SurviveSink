using UnityEngine;
using System.Collections;

public class WakeUpRigidbody : MonoBehaviour {
    Rigidbody rigidbody;

	// Use this for initialization
	void Start () {
        rigidbody = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
        if (rigidbody.IsSleeping())
        {
            rigidbody.WakeUp();
        }
    }
}
