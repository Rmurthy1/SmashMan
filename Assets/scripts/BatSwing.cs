using UnityEngine;
using System.Collections;

public class BatSwing : MonoBehaviour
{
	Transform _transform;
	Quaternion _startRotation;
	Quaternion _endRotation;
	Quaternion _currentRotation;
	bool swing = false;
	bool readyToSwing = true;

	int swingSpeed = 50;
	// Use this for initialization
	void Start ()
	{
		_transform = GetComponent<Transform> ();
		_currentRotation = _transform.rotation;
		_startRotation = GameObject.FindGameObjectWithTag("startswing").GetComponent<Transform>().rotation;
		_endRotation = GameObject.FindGameObjectWithTag ("endswing").GetComponent<Transform>().rotation;
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
		if (readyToSwing == true) {

			swing = true;
			readyToSwing = false;
		}

	}

	// Update is called once per frame

	void Update()
	{
		// lets try it using the RotateTowards function
		if (Input.GetKeyDown ("space")) {
			swingFunc ();
		}
		if (swing == true) 
		{
			transform.rotation = Quaternion.Slerp (_currentRotation, _endRotation, swingSpeed * Time.deltaTime);
			_currentRotation = transform.rotation;
			if (_currentRotation == _endRotation) {
				swing = false;
			}
		} 
		else if (swing == false && readyToSwing == false) 
		{
			transform.rotation = Quaternion.Slerp (_currentRotation, _startRotation, swingSpeed * Time.deltaTime);
			_currentRotation = transform.rotation;
			if (_currentRotation == _startRotation) {
				readyToSwing = true;
			}
		}
	}


}