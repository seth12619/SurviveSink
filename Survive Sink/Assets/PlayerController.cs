using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

    public float speed = 1000.0f;
    public Rigidbody rb;

	// Use this for initialization
	void Start () {
	
	}

    void FixedUpdate()
    {

    }
	
	// Update is called once per frame
	void Update () {
        rb = GetComponent<Rigidbody>();

        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 move = new Vector3(moveHorizontal, 0.0f, moveVertical);


        rb.AddForce(move * speed);


	}
}
