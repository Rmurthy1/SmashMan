using UnityEngine;
using System.Collections;

public class HoverMotor : MonoBehaviour {

	public float speed = 90f;
	public float turnSpeed = 1f;
	public float hoverForce = 20f;
	public float hoverHeight = 3.5f;
	private float powerInput;
	private float turnInput;
	private Rigidbody carRigidbody;
	//private float jumpTime = 3f;
	
	// TODO things!
	IEnumerator Jump() {
        print(Time.time);
		hoverForce = 300f;
		hoverHeight = 200f;
        yield return new WaitForSeconds(5);
		hoverForce = 65f;
		hoverHeight = 3.5f;
        print(Time.time);
    }

	void Awake () 
	{
		carRigidbody = GetComponent <Rigidbody>();
	}
	
	void Update () 
	{
		powerInput = Input.GetAxis ("Vertical");
		turnInput = Input.GetAxis ("Horizontal");
		/*if (Input.GetKeyDown("space"))
		{
			Debug.Log("pressed space");
			//StartCoroutine(Jump());
		}
		*/
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
		
	}
}