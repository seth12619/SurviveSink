using UnityEngine;
using System.Collections;

public class TiltingGrav : MonoBehaviour {
    WaitTilting wt;
    Rigidbody rg;

	// Use this for initialization
	void Start () {
        GameObject ship = GameObject.Find("Ship");
        wt = ship.GetComponent<WaitTilting>();
        rg = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
        float x = wt.getCurrXDeg();
        float z = wt.getCurrZDeg();

        rg.AddForce(new Vector3(-z,0,x)*Time.deltaTime*500);
	}
}
