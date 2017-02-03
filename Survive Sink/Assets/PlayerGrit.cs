using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerGrit : MonoBehaviour {

	public int startingGrit = 100;
	public int currentGrit;
	public Slider gritslider;
	public Image damageImage;
	public float flashSpeed = 4.0f;
	public Color flashColor = new Color(1.0f, 0, 0, 1.0f);
	bool damaged;

	Animator anim;

	void Awake (){
		anim = GetComponent <Animator> ();


		currentGrit = startingGrit;
	}
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		// If the player has just been damaged...
		if(damaged)
		{
			// ... set the colour of the damageImage to the flash colour.
			damageImage.color = flashColor;
		}
		// Otherwise...
		else
		{
			// ... transition the colour back to clear.
			damageImage.color = Color.Lerp (damageImage.color, Color.clear, flashSpeed * Time.deltaTime);
		}

		// Reset the damaged flag.
		damaged = false;
	}

	public void takeDamage (int amounnt)
	{
		damaged = true;

		currentGrit -= amounnt;

		gritslider.value = currentGrit;
	}
}
