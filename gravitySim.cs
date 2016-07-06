using UnityEngine;
using System.Collections;



public class gravitySim : MonoBehaviour 
{
	Vector2 gravDirection;
	public float gravForce = 2.0f;
	private GameObject asteroid;
	GameObject player;
	groundedScript gs;
	bool landerIsGrounded;

	void Start ()
	{
		asteroid = this.gameObject;

		//player = GameObject.Find("lander");

		//gs = player.GetComponent<groundedScript>();
		//groundScript = GameObject.FindObjectOfType(typeof(groundedScript)) as groundedScript;

	}


	void OnTriggerStay2D(Collider2D other)
	{
		if (other.tag == "Player") 
		{
			gravDirection = asteroid.transform.position - other.transform.position;

			other.GetComponent<Rigidbody2D>().AddForce (gravDirection * (1/gravDirection.magnitude) * gravForce);
		}
	}

}