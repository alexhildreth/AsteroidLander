//if player is dead, destroys player object, waits a preset amount of time, then reloads.

using UnityEngine;
using System.Collections;

public class deathScript : MonoBehaviour {

	GameObject lander;
	public thrusterScript other;
	bool isDead = false;
	float deathTimer = 0.0f;

	void Start()
	{
		lander = GameObject.FindWithTag ("Player");
	}

	void FixedUpdate()
	{
		if(lander != null)
		{
			isDead = other.getDead();
		}

		if (isDead) 
		{
			if(lander != null)
			{
				Destroy(lander);
			}
			deathTimer += Time.fixedDeltaTime;
			if(deathTimer >= 4.0f)
			{
				Application.LoadLevel(Application.loadedLevel);
			}
		    
		}
	}
}
