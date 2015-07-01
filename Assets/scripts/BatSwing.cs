using UnityEngine;
using System.Collections;

public class BatSwing : MonoBehaviour
{
	Transform _transform;
	Transform _startRotation;
	Transform _endRotation;
	bool swing = false;
	bool readyToSwing = true;

	int swingSpeed = 200;
	// Use this for initialization
	void Start ()
	{
		_transform = GetComponent<Transform> ();
		_startRotation = GameObject.FindGameObjectWithTag("startswing").GetComponent<Transform>();
		_endRotation = GameObject.FindGameObjectWithTag ("endswing").GetComponent<Transform>();
	}


	// batswing coroutine
	IEnumerator swingAnimation() {
		print(Time.time);
		//hoverForce = 300f;
		//hoverHeight = 200f;
		yield return new WaitForSeconds(5);
		//hoverForce = 65f;
		//hoverHeight = 3.5f;
		print(Time.time);
	}

	void swingFunc ()
	{
		//batSwing.SetTrigger ("IsSwinging");
		//_transform.Rotate (Vector3.up, 90.0f);
		if (readyToSwing == true) {
			swing = true;
			readyToSwing = false;
		}

	}

	// Update is called once per frame
	void Update ()
	{
		// swing if space pressed
		if (Input.GetKeyDown ("space")) {
			//Debug.Log("pressed space");

			// call the function to do it
			swingFunc ();
		}

		// if we are swinging
		if (swing == true) {
			// if the rotation is too far, stop it
			if (Quaternion.Angle(_transform.rotation, _endRotation.rotation) < 90.0f && readyToSwing == false)
			{
				swing = false;
			}
			// otherwise swing it
			else
			{
				_transform.Rotate(Vector3.up, Time.deltaTime * swingSpeed);
			}
		}
		// if the rotation is greater than zero, but we are not swinging
		if (Quaternion.Angle(_transform.rotation, _startRotation.rotation) > 90.0f && swing == false && readyToSwing == false)
		{
			// bring it back
			_transform.Rotate (Vector3.up, -Time.deltaTime * swingSpeed);
		}
		// otherwise if the rotation is just too short then we are ready too swing again
		else if (Quaternion.Angle(_transform.rotation, _startRotation.rotation) <= 90.0f && swing == false) 
		{
			readyToSwing = true;
		} 
	}
}