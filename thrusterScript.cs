using UnityEngine;
using System.Collections;

public class thrusterScript : MonoBehaviour
{
	//thruster force
	public float thrustForce = 5f;
	public float rotateSpeed = 5f;
	public float torqueForce = 0.5f;

	//crash max speed
	public float crashSpeed = 10.0f;
	
	Vector3 leftPos;
	Vector3 rightPos;

	//finds local game object for manipulation
	private GameObject lander;
	private GameObject soundFX;

	public groundedScript other; //for getting isGrounded status from other script
	public deathScript death; //for getting death status
	public bool dead = false;

	bool isGrounded = false;

	//sounds
	public AudioSource thrustSound;
	public AudioSource explode;

	// Use this for initialization
	void Start ()
	{
		Debug.Log("Test");
		lander = GameObject.Find("lander");

		soundFX = GameObject.FindWithTag ("soundFX");
	}
	
	// Update is called once per frame
	void Update ()
	{

	}

	void FixedUpdate()
	{
		//grounded?
		isGrounded = other.getGrounded ();

		//main thruster
		GetComponent<ParticleSystem>().emissionRate = 0;
		if (Input.GetKey ("w")) 
		{
			lander.GetComponent<Rigidbody2D>().AddForce(lander.transform.up * thrustForce);
			GetComponent<ParticleSystem>().emissionRate = 100;

			//play thruster sound if not already playing
			if(!thrustSound.isPlaying){
				thrustSound.Play();
			}
		}

		if (Input.GetKeyUp ("w")) 
		{
			thrustSound.Stop();
		}

		//left thruster
		if(Input.GetKey ("a")) 
		{
			//normal mode rotate
			lander.transform.Rotate(0.0f, 0.0f, -1.0f*rotateSpeed, Space.Self);

			//hard mode rotate
			lander.GetComponent<Rigidbody2D>().AddTorque(-torqueForce);
		}

		//right thruster
		if (Input.GetKey ("d")) 
		{
			//normal mode rotate
			lander.transform.Rotate(0.0f, 0.0f, 1.0f*rotateSpeed, Space.Self);

			//hard mode rotate
			lander.GetComponent<Rigidbody2D>().AddTorque(torqueForce);
		}

		//auto rotation correct
		if(GetComponent<Rigidbody2D>().angularVelocity != 0)
		{
			lander.GetComponent<Rigidbody2D>().AddTorque(-0.08f * GetComponent<Rigidbody2D>().angularVelocity);
		}


	}



	//destroy if crash
	void OnCollisionEnter2D(Collision2D other)
	{
		Debug.Log("Crashed");
		Debug.Log(lander.GetComponent<Rigidbody2D>().velocity.magnitude.ToString("F4"));
		if (!isGrounded || lander.GetComponent<Rigidbody2D>().velocity.magnitude > crashSpeed) 
		{
			soundFX.GetComponent<AudioSource>().Play();
			//set dead status
			dead = true;
		}
	}

	//sends death status
	public bool getDead()
	{
		return dead;
	}

}
