//stores and updates the public variable grounded to tell if lander is on surface

//stops player from rotating if spinning

using UnityEngine;
using System.Collections;

public class groundedScript : MonoBehaviour {

	public bool landerGrounded;
	public bool onPad;
	private GameObject playerPads;

	// Use this for initialization
	void Start () 
	{
		landerGrounded = false;
		onPad = false;

		playerPads = this.gameObject;
	}
	
	void onTriggerEnter2D(Collider2D other)
	{
		//player.rigidbody2D.isKinematic = true;
	}
	
	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "asteroid" || other.tag == "landingPad")
		{
			landerGrounded = true;
		}

		if (other.tag == "landingPad")
		{
			onPad = true;
		}
	}

	void OnTriggerExit2D(Collider2D other)
	{
		if (other.tag == "asteroid" || other.tag == "landingPad")
		{
			landerGrounded = false;
		}

		if (other.tag == "landingPad")
		{
			onPad = false;
		}
	}

	public bool getGrounded()
	{
		return landerGrounded;
	}

	public bool getOnPad()
	{
		return onPad;
	}
}
