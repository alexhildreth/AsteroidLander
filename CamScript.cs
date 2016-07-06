using UnityEngine;
using System.Collections;

public class CamScript : MonoBehaviour {
	private Transform player;
	// Use this for initialization
	void Start () 
	{
		player = GameObject.Find ("lander").transform;
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(player != null)
		{
		Vector3 playerPos = player.position;
		playerPos.z = transform.position.z;
		transform.position = playerPos;
		}
	}
}
