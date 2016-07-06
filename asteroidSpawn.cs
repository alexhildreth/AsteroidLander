//Spawns a given number of asteroids on the play field

using UnityEngine;
using System.Collections;

public class asteroidSpawn : MonoBehaviour {

	public Transform Asteroid;
	// Use this for initialization
	void Start () 
	{
		int j = 0;
		//spawn 3 asteroids
		for(int i = 0; i < 3; i++)
		{
			j = -j;
			Instantiate(Asteroid, new Vector3(i * 30.0f, j * 30.0f, 0), Quaternion.identity);

			if(j < 0) j--;
			else j++;
		}
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}
}
