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
	
	public float invinciTime = 10f;
	public float timePassed = 0f;

	Animator anim;

	public UpAndDown upDown;
	public UnityChanControlScriptWithRgidBody player;
	public LeftHand leftHand;
	public RightHand rightHand;

	void Awake (){
		anim = GetComponent <Animator> ();


		currentGrit = startingGrit;
	}
	// Use this for initialization
	void Start () {
		upDown = GameObject.FindGameObjectWithTag("UpAndDown").GetComponent<UpAndDown>();
		player = GameObject.FindGameObjectWithTag("Player").GetComponent<UnityChanControlScriptWithRgidBody>();
		leftHand = GameObject.FindGameObjectWithTag("Player").GetComponent<LeftHand>();
		rightHand = GameObject.FindGameObjectWithTag("Player").GetComponent<RightHand>();
	}
	
	// Update is called once per frame
	void Update () {
		timePassed += Time.deltaTime;
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
	
	public void gotHit(GameObject collidedWith){
		if(timePassed>invinciTime){
			float magnitude = collidedWith.GetComponent<Rigidbody>().velocity.magnitude;
			if(magnitude>1.0f){
				
				takeDamage(8);
			}
		}
	}
	
	public void fire(){
		if(timePassed>invinciTime){
			player.rb.velocity = -8 * player.rb.velocity;
				
			takeDamage(19);
		}
	}
	
    /**
     * passingDuty of takeDamage as a factor here.
     */
	public void takeDamage (int amounnt)
	{
		timePassed = 0f;
		StartCoroutine(upDown.upAndDown());
		StartCoroutine(leftHand.detachFromPlayer());
		StartCoroutine(rightHand.detachFromPlayer());
		
		damaged = true;

		currentGrit -= amounnt;

		gritslider.value = currentGrit;
		
		if(currentGrit <= 0)
		{
			death();
		}
	}
	
	public void death()
	{
		StartCoroutine(GameObject.Find("Tracker").GetComponent<MainTracker>().endDay());
		Destroy(GameObject.Find("Ship"));
	}
}
