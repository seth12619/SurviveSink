using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public float speed = 6.0f;
	public float gravity = 10.0f;
	public float maxChange = 10.0f;
	public bool canJmp = true;
	public float jumpHeight = 1.25f;
	public bool grounded = false;
	public float frontInput;
	public float sideInput;
	public bool jumpInput;
	public GameObject player;
    public Rigidbody rb;

	// Use this for initialization
	void Start () {
	
	}

	void Awake()
	{
		player = GameObject.FindWithTag ("Player");
		rb = player.GetComponent (typeof(Rigidbody)) as Rigidbody;
		rb.freezeRotation = true;
		rb.useGravity = false;
	}
		
	
	// Update is called once per frame
	void Update () {

		sideInput = Input.GetAxis ("Horizontal");
		frontInput = Input.GetAxis ("Vertical");
		jumpInput = Input.GetButton ("Jump");
	}

	void FixedUpdate(){
		if (grounded) {
			Vector3 target = new Vector3 (Input.GetAxis ("Horizontal"), 0, Input.GetAxis ("Vertical"));
			target = transform.TransformDirection (target);
			target *= speed;

			Vector3 velocity = rb.velocity;
			Vector3 velocityDelta = (target - velocity);
			velocityDelta.x = Mathf.Clamp (velocityDelta.x, -maxChange, maxChange);
			velocityDelta.z = Mathf.Clamp (velocityDelta.z, -maxChange, maxChange);
			velocityDelta.y = 0;
			rb.AddForce (velocityDelta, ForceMode.VelocityChange);

			//Jump
			if (canJmp && jumpInput) {
				rb.velocity = new Vector3(velocity.x, Mathf.Sqrt(2 * jumpHeight * gravity), velocity.z) ;
			}

			//Gravity application
			rb.AddForce(new Vector3(0, - gravity * rb.mass, 0));

			grounded = false;
		}
			
	}
	void OnCollisionStay(){
		grounded = true;
	}

		
}
