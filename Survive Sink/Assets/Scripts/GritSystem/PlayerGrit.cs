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
	
	public MainTracker tracker;

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
		
		tracker = GameObject.Find("Tracker").GetComponent<MainTracker>();
	}
	
	// Update is called once per frame
	void Update () {
		timePassed += Time.deltaTime;
	}
	
	public void gotHit(GameObject collidedWith){
		if(timePassed>invinciTime){
			float magnitude = collidedWith.GetComponent<Rigidbody>().velocity.magnitude;
			if(magnitude>1.0f){
				
				takeDamage(180);
			}
		}
	}
	
	public void fire(){
		if(timePassed>invinciTime){				
			takeDamage(250);
		}
	}
	
    /**
     * passingDuty of takeDamage as a factor here.
     */
	public void takeDamage (int amount)
	{
		timePassed = 0f;
		StartCoroutine(upDown.upAndDown());
		StartCoroutine(leftHand.detachFromPlayer());
		StartCoroutine(rightHand.detachFromPlayer());
		
		damaged = true;
		
		if(tracker.hasStamina()){
			StartCoroutine(tracker.useStamina(amount));
			damageFlash();
		}else{
			death();
		}
	}
	
	public void damageFlash(){
		return;
	}
	
	public void death()
	{
		Destroy(GameObject.Find("Ship"));
		StartCoroutine(tracker.endDay());
	}
}
