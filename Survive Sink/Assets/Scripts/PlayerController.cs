using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public float speed = 6.0f;
	public float gravity = 9.8f;
	public float maxVelocityChange = 10.0f;
	public bool jump = true;
	public bool jumpButton;
	public float jumpHeight = 2.0f;
	private bool grounded = false;
	private float moveHorizontal;
	private float moveVertical;

    public Rigidbody rb;
	public GameObject player;

	// Use this for initialization
	void Start () {
		
	}
	//Gets called at the first instance
	//Is still called even when script is disabled
	void Awake(){
		player = GameObject.FindWithTag ("Player");
		rb = GetComponent<Rigidbody>();

		rb.freezeRotation = true;
		rb.useGravity = false;
	}
	
	// Update is called once per frame
	//Irregular Timeline
	void Update () {
        moveHorizontal = Input.GetAxis("Horizontal");
        moveVertical = Input.GetAxis("Vertical");
		jumpButton = Input.GetButton ("Jump");
        Vector3 move = new Vector3(moveHorizontal, 0.0f, moveVertical);
        rb.AddForce(move * speed);
	}
	void FixedUpdate()
	{
		if (grounded) {
			//Calculate how fast we should be moving
			Vector3 targetVelo = new Vector3(moveHorizontal, 0, moveVertical);
			targetVelo = transform.TransformDirection (targetVelo);
			targetVelo *= speed;

			//Apply a force that attempts to reach the velocity
			Vector3 velocity = rb.velocity;
			Vector3 velocityChange = (targetVelo - velocity);
			velocityChange.x = Mathf.Clamp (velocityChange.x, -maxVelocityChange, maxVelocityChange);
			velocityChange.z = Mathf.Clamp (velocityChange.z, -maxVelocityChange, maxVelocityChange);
			velocityChange.y = 0;
			rb.AddForce (velocityChange, ForceMode.VelocityChange);

			//Jump
			if (jump && jumpButton) {
				rb.velocity = new Vector3 (velocity.x, jumpSpeed(), velocity.z);
			}
		}

		// We apply gravity manually for more tuning control
		rb.AddForce(new Vector3(0, -gravity * rb.mass, 0));

		grounded = false;
	}
	float jumpSpeed(){
		return Mathf.Sqrt (2 * jumpHeight * gravity);
	}

	void OnCollisionStay()
	{
		grounded = true;
	}

}
