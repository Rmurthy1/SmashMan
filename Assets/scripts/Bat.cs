using UnityEngine;
using System.Collections;

public class Bat : MonoBehaviour {
	private Animator batSwing;

	// Use this for initialization
	void Start () {


	}
	/*void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "mailbox") {
			//other.gameObject.SetActive (false);
			Rigidbody boxBody;
			BoxCollider boxCollider;
			boxBody = other.gameObject.GetComponent<Rigidbody>();
			boxBody.useGravity = true;
			boxCollider = other.gameObject.GetComponent<BoxCollider>();
			boxCollider.isTrigger = false;

		}
	}
	*/
	void OnCollisionEnter(Collision collision)
	{
		Collider other = collision.collider;
		if (other.gameObject.tag == "mailbox") {
			// get first contact point
			ContactPoint contact = collision.contacts [0];


			// not sure what this does
			// Quaternion rot = Quaternion.FromToRotation (Vector3.up, contact.normal);



			// get the point of the collision
			Vector3 pos = contact.point;
			// print out what touched what
			Debug.Log (contact.thisCollider.name + " hit " + contact.otherCollider.name);
			// setup for the hit
			Rigidbody boxBody;

			//BoxCollider boxCollider;
			// get the rigidbody
			boxBody = other.gameObject.GetComponent<Rigidbody>();
			// give it gravity
			boxBody.useGravity = true;
			//boxCollider = other.gameObject.GetComponent<BoxCollider>();
			//boxBody.AddExplosionForce(50f, pos, 0f, 1f, ForceMode.Impulse);

			// calculate where the hit took place
			Vector3 force = boxBody.transform.position - transform.position;
			// multiply it by some power (50 is what im using now)
			Rigidbody CarBody =  GameObject.FindGameObjectWithTag("car").GetComponent<Rigidbody>();
			Debug.Log(Mathf.Abs(CarBody.velocity.x));
			force = force * Mathf.Abs(CarBody.velocity.x) * 5;
			boxBody.AddForceAtPosition(force, pos, ForceMode.Impulse);
		}
	}
}
