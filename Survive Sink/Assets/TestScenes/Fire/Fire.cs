using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour {
	float TimeInterval = 0.25f;
	float timePassed = 0f;
	float expireTime = 180f;
	float startedWithTime;
	public GameObject fire;
	public bool onFire = true;
	
	Flammable burn;

	// Use this for initialization
	void Start () {
		StartCoroutine(createFire());
		startedWithTime = expireTime;
		
		burn = transform.parent.gameObject.GetComponent<Flammable>();
	}
	
	// Update is called once per frame
	void Update() {
		if(onFire){
			expireTime -= Time.deltaTime;
			
			float absTimePassed = startedWithTime * 1.1f - expireTime;
			float modifier = absTimePassed * absTimePassed / startedWithTime / startedWithTime;
			
			timePassed += Time.deltaTime * modifier;
			if(timePassed > TimeInterval){
				timePassed = 0;
				StartCoroutine(createFire());
			}
			
			if(expireTime < 0){
				if(burn != null)
					StartCoroutine(burn.burn());
				else
					Destroy(transform.parent.gameObject);
			}
		}
	}
	
	IEnumerator createFire(){
		Instantiate(fire, transform.position, transform.rotation);
		yield return null;
	}
}
