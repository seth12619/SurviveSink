using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.ImageEffects;

public class FogToCamera : MonoBehaviour {	

	// Use this for initialization
	void Start () {
		GlobalFog fog = GetComponent<GlobalFog>();
		GameObject[] cameras = GameObject.FindGameObjectsWithTag("MainCamera");
		foreach(GameObject camera in cameras){
			CopyComponent(fog, camera);
		}
		
		Destroy(fog);
		Destroy(GetComponent<Camera>());
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	
	Component CopyComponent(Component original, GameObject destination)
	{
		System.Type type = original.GetType();
		Component copy = destination.AddComponent(type);
		// Copied fields can be restricted with BindingFlags
		System.Reflection.FieldInfo[] fields = type.GetFields(); 
		foreach (System.Reflection.FieldInfo field in fields)
		{
			field.SetValue(copy, field.GetValue(original));
		}
		return copy;
	}
}
