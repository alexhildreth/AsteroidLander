using UnityEngine;
using System.Collections;

public class rightThrustScript : MonoBehaviour {
	GameObject rightThrust;
	// Use this for initialization
	void Start () 
	{
		rightThrust = GameObject.FindGameObjectWithTag ("rightThruster");
	}
	
	void FixedUpdate()
	{
		//side thruster particles
		GetComponent<ParticleSystem>().emissionRate = 0;
		if (Input.GetKey ("d")) 
		{
			rightThrust.GetComponent<ParticleSystem>().emissionRate = 70;
		}
	}
}
