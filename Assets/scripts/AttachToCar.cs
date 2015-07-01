using UnityEngine;
using System.Collections;

public class AttachToCar : MonoBehaviour {

	private GameObject player;
	private Vector3 offset;

	void Start () {
		player = GameObject.FindGameObjectWithTag ("car");
		offset = GetComponent<Transform> ().position - player.GetComponent<Transform>().position; //transform.position;

	}
	
	// Update is called once per frame
	void Update () {
		GetComponent<Transform> ().position = player.GetComponent<Transform> ().position + offset;
		
	}
}
