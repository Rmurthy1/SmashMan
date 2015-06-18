using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CarPickupBehavior : MonoBehaviour {

	private int count;
	public Text countText;
	public Text winText;
	private const int WIN_AMOUNT = 1;

	// Use this for initialization
	void Start () {
		count = 0;
		SetText ();
		winText.text = "";
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "PickUp") {
			other.gameObject.SetActive (false);
			count = count + 1;
			SetText();
			
		}
	}
	void SetText()
	{
		countText.text = "Count = " + count.ToString ();
		if (count >= WIN_AMOUNT) {
			winText.text = "YOU WIN!";
		}
	}
}
