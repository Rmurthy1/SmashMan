﻿using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

	public GameObject player;
	private Vector3 offset;

	// Use this for initialization
	void Start () {
		offset = GetComponent<Transform> ().position - player.GetComponent<Transform>().position; //transform.position;

	}
	
	// Update is called once per frame
	void LateUpdate () {
		GetComponent<Transform> ().position = player.GetComponent<Transform> ().position + offset;
	
	}
}
