using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpAndDown : MonoBehaviour {
	private int shift = 0;
	
	public int shiftFramesX = 0;
	public int shiftFramesY = 30;
	public int shiftFramesZ = 20;
	
	public float speedShiftX = 0;
	public float speedShiftY = -0.015f;
	public float speedShiftZ = 0.008f;
	
	public float waitDownTime = 2f;
	private float timePassed = 0f;
	private int fallSpeed = 3;
	
	private int move = 0;
	private UnityChanControlScriptWithRgidBody ucswr;
	
	private float backwardSpeed;
	private float forwardSpeed;
	private float strafeSpeed;

	// Use this for initialization
	void Start () {
		shiftFramesX*=fallSpeed;
		shiftFramesY*=fallSpeed;
		shiftFramesZ*=fallSpeed;
		
		ucswr = GameObject.FindGameObjectWithTag("Player").GetComponent<UnityChanControlScriptWithRgidBody>();
		
		backwardSpeed = ucswr.backwardSpeed;
		forwardSpeed = ucswr.forwardSpeed;
		strafeSpeed = ucswr.strafeSpeed;
	}
	
	// Update is called once per frame
	void Update () {
		Debug.Log(move);
		if(move!=0&&move!=1){
			ucswr.backwardSpeed = 0;
			ucswr.forwardSpeed = 0;
			ucswr.strafeSpeed = 0;
		}
		if(move == -1){
			bool temp = false;
			if(shiftFramesX > shift){
				temp = true;
				transform.localPosition = new Vector3(transform.localPosition.x + speedShiftX*fallSpeed, 
					transform.localPosition.y, transform.localPosition.z);
			}
			if(shiftFramesY > shift){
				temp = true;
				transform.localPosition = new Vector3(transform.localPosition.x, 
					transform.localPosition.y + speedShiftY*fallSpeed, transform.localPosition.z);
			}
			if(shiftFramesZ > shift){
				temp = true;
				transform.localPosition = new Vector3(transform.localPosition.x, 
					transform.localPosition.y, transform.localPosition.z + speedShiftZ*fallSpeed);
			}
			shift+=fallSpeed;
			if(!temp){
				shift = 0;
				move = -2;
			}
			
		}else if(move == -2){
			timePassed += Time.deltaTime;
			if(timePassed > waitDownTime){
				timePassed = 0;
				move = 1;
			}
			
		}else if(move == 1){
			bool temp = false;
			
			ucswr.backwardSpeed = backwardSpeed * shift * shift / shiftFramesY / shiftFramesY;;
			ucswr.forwardSpeed = forwardSpeed * shift * shift / shiftFramesY / shiftFramesY;;
			ucswr.strafeSpeed = strafeSpeed * shift * shift / shiftFramesY / shiftFramesY;
			
			if(shiftFramesX > shift){
				temp = true;
				transform.localPosition = new Vector3(transform.localPosition.x - speedShiftX, 
					transform.localPosition.y, transform.localPosition.z);
			}
			if(shiftFramesY > shift){
				temp = true;
				transform.localPosition = new Vector3(transform.localPosition.x, 
					transform.localPosition.y - speedShiftY, transform.localPosition.z);
			}
			if(shiftFramesZ > shift){
				temp = true;
				transform.localPosition = new Vector3(transform.localPosition.x, 
					transform.localPosition.y, transform.localPosition.z - speedShiftZ);
			}
			shift++;
			if(!temp){
				move = 0;
				shift = 0;
			}
		}else{
			ucswr.backwardSpeed = backwardSpeed;
			ucswr.forwardSpeed = forwardSpeed;
			ucswr.strafeSpeed = strafeSpeed;
		}
	}
	
	public IEnumerator upAndDown(){
		if(move == -2){
			yield return null;
		}
		if(move == 1){
			yield return null;
		}
		move = -1;
		
		yield return null;
	}
}
