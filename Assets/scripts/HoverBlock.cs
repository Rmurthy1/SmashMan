using UnityEngine;
using System.Collections;

public class HoverBlock : MonoBehaviour {
	public float hoverForce = 80f;
	public float hoverHeight = 3.5f;
	private Rigidbody carRigidbody;
	private float powerInput;
	private float turnInput;
	public float speed = 90f;
	public float turnSpeed = 1f;


	// Use this for initialization
	void Start () {
		carRigidbody = GetComponent <Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
		powerInput = Input.GetAxis ("Vertical");
		turnInput = Input.GetAxis ("Horizontal");
	}
	void FixedUpdate()
	{
		Ray ray = new Ray (transform.position, -transform.up);
		RaycastHit hit;
		
		
		// returns true if the ray that we draw is hitting a collider, information about the hit is in "hit"
		if (Physics.Raycast(ray, out hit, hoverHeight))
		{
			float proportionalHeight = (hoverHeight - hit.distance) / hoverHeight;
			Vector3 appliedHoverForce = Vector3.up * proportionalHeight * hoverForce;
			carRigidbody.AddForce(appliedHoverForce, ForceMode.Acceleration);
		}
		if (powerInput < 0) {
			powerInput = 0;
		}
		carRigidbody.AddRelativeForce(0f, 0f, -powerInput * speed);
		carRigidbody.AddRelativeTorque(0f, turnInput * turnSpeed, 0f);

		//Debug.Log (carRigidbody.velocity);
	}
}
