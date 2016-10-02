using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public float speed = 6.0f;
	public float maxChange = 10.0f;
	public float gravity = 10.0f;
	public float frontInput;
	public float sideInput;
	public bool jumpInput;
	public bool canJmp;
	public float jumpHeight = 0.5f;
	public bool grounded = false;

	public GameObject player;
    public Rigidbody rb;

	// Use this for initialization
	void Start () {
	
	}

	void Awake()
	{
		player = GameObject.FindWithTag ("Player");
		rb = player.GetComponent (typeof(Rigidbody)) as Rigidbody;
		rb.useGravity = false;
		rb.freezeRotation = true;
	}
	
	// Update is called once per frame
	void Update () {

		sideInput = Input.GetAxis("Horizontal");
		frontInput = Input.GetAxis("Vertical");
		jumpInput = Input.GetButton ("Jump");
	}

	void FixedUpdate(){
		if (grounded) {

			Vector3 target = new Vector3 (sideInput, 0, frontInput);
			target = transform.TransformDirection (target);
			target *= speed;

			Vector3 velocity = rb.velocity;
			Vector3 delta = target - velocity;
			delta.x = Mathf.Clamp (delta.x, -maxChange, maxChange);
			delta.z = Mathf.Clamp (delta.z, -maxChange, maxChange);
			delta.y = 0;
			rb.AddForce (delta, ForceMode.VelocityChange);

			if (canJmp && jumpInput) {
				rb.AddForce (velocity.x, (2 * jumpHeight * gravity), velocity.z);
			}

			rb.AddForce (new Vector3 (0, -gravity * rb.mass, 0));

			grounded = false;
		}
	}

	void OnCollisionStay()
	{
		grounded = true;
	}
}
