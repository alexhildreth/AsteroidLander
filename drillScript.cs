using UnityEngine;
using System.Collections;

public class drillScript : MonoBehaviour {
	GameObject Drill;
	public groundedScript other; //for getting isGrounded status from other script
	public float score;
	bool isGrounded = false;
	bool isMining = false;
	bool onPad = false;

	//variable for minerals in cargo hold
	float minerals;

	// Use this for initialization
	void Start () 
	{
		Drill = GameObject.FindGameObjectWithTag ("Drill");
		score = 0.0f;
	}
	
	// Update is called once per frame
	void FixedUpdate () 
	{
		//find out if grounded or on landing pad
		isGrounded = other.getGrounded ();
		onPad = other.getOnPad ();
		GetComponent<ParticleSystem>().emissionRate = 0;

		//start mining if groudned
		if (isGrounded) 
		{
			if (Input.GetKey ("space")) 
			{
				isMining = true;
			}

		}
		//stop mining
		if (Input.GetKeyUp ("space") || Input.GetKey ("w") || minerals >= 10.0f) 
		{
			isMining = false;
		}

		//while mining, play animation and fill cargo hold
		if (isMining) 
		{
			Drill.GetComponent<ParticleSystem>().emissionRate = 70;
			minerals += Time.fixedDeltaTime;
			//play sound
			if(!GetComponent<AudioSource>().isPlaying)
			{
				GetComponent<AudioSource>().Play();
			}
		}

		if (Input.GetKeyUp ("space")) 
		{
			GetComponent<AudioSource>().Stop();
		}

		if (onPad) 
		{
			if(minerals > 0)
			{
				minerals -= Time.fixedDeltaTime;
				score += Time.fixedDeltaTime;
				//play sound
				if(!GetComponent<AudioSource>().isPlaying)
				{
					GetComponent<AudioSource>().Play();
				}
			}

		}

	
	}

	//print minerals on screen
	void OnGUI()
	{
		GUI.Label(new Rect(0,0,600,600), "Minerals in hold: ");
		GUI.Label(new Rect(100,0,600,600), minerals.ToString());

		//show score
		GUI.Label(new Rect(0,20,300,300), "Score: ");
		GUI.Label(new Rect(100,20,300,300), score.ToString());
	}

	
}
