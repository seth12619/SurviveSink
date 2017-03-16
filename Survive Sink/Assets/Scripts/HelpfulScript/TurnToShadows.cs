using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnToShadows : MonoBehaviour {

	// Use this for initialization
	void Start () {
		SkinnedMeshRenderer[] mr = GetComponentsInChildren<SkinnedMeshRenderer>();
		foreach(SkinnedMeshRenderer me in mr){
			me.shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.ShadowsOnly;
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
