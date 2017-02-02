#pragma strict

// Counts up from 0.0 by 1 second

var Timer = 0.0;
 private var ifFinished: boolean = true;
 var style = new GUIStyle();

function Start () {

}

function Update () {
	Timer = Timer + Time.deltaTime;
}

function OnGUI() {
	 if(ifFinished) {
        style.fontSize=50;
        GUI.Label (Rect (10, 30, 1000, 20),"Time: " +Timer,style);
     }
}