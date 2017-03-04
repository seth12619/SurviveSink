using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteSelf : MonoBehaviour {
    public float DeleteMeInSecs = 0.01f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        DeleteMeInSecs -= Time.deltaTime;
        if(DeleteMeInSecs < 0)
        {
            Destroy(gameObject);
        }
	}
}
