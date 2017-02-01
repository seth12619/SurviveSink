using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerGrit : MonoBehaviour {

	public int startingGrit = 1000;
	public int currentGrit;
	public Slider gritslider;
	public Image damageImage;
	public float flashSpeed = 4.0f;
	public Color flashColor = new Color(1.0f, 0, 0, 1.0f);
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
