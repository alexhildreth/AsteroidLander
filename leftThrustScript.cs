using UnityEngine;
using System.Collections;

public class leftThrustScript : MonoBehaviour {
	GameObject leftThrust;
	// Use this for initialization
	void Start () 
	{
		leftThrust = GameObject.FindGameObjectWithTag ("leftThruster");
	}
	
	void FixedUpdate()
	{
		//side thruster particles
		GetComponent<ParticleSystem>().emissionRate = 0;
		if (Input.GetKey ("a")) 
		{
			leftThrust.GetComponent<ParticleSystem>().emissionRate = 70;
		}
	}
}
