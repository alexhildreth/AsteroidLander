//generates a random point inside a circle to initialize asteroid movement

using UnityEngine;
using System.Collections;

public class asteroidInit : MonoBehaviour {

	//randomize initial movement. Set a random constant speed
	private Vector2 asteroidVec;
	public float asteroidSpeed = 1.0f;
	public Vector2 initialSpeed;
	private float constantSpeed;
	public float maxSpeed = 12.0f;
	private GameObject asteroid;

	// Use this for initialization
	void Start () 
	{
		asteroid = this.gameObject;
		asteroidVec = Random.insideUnitCircle;
		asteroid.GetComponent<Rigidbody2D>().AddForce (asteroidVec * asteroidSpeed);
		constantSpeed = Random.Range (1.0f, maxSpeed);
		initialSpeed = asteroid.GetComponent<Rigidbody2D>().velocity;
	}
	
	// Update is called once per frame
	void FixedUpdate () 
	{
		//make sure asteroid always travels the same speed
		asteroid.GetComponent<Rigidbody2D>().velocity = constantSpeed * asteroid.GetComponent<Rigidbody2D>().velocity.normalized;

		/*
		if(currentSpeed.magnitude < initialSpeed.magnitude) 
		{
			asteroid.rigidbody2D.AddForce (currentSpeed * 50 * asteroidSpeed);
		}
		*/
	}
}
