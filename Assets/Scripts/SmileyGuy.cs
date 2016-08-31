using UnityEngine;
using System.Collections;

public class SmileyGuy : MonoBehaviour 
{
	private bool isAlive;
	private Rigidbody rigidBody;
	private Vector3 defaultPosition;

	// Events.
	public delegate void EventTriggerEnter(Collider collider);
	public event EventTriggerEnter onEventTriggerEnter;

	// Use this for initialization
	void Start () 
	{
		isAlive = true;
		rigidBody = gameObject.GetComponent<Rigidbody>();
		defaultPosition = new Vector3(-5.3f, 2f, -0.38f);
	}
	
	public void Reset() 
	{
		transform.position = defaultPosition;
		rigidBody.velocity = new Vector3(0, 0, 0);
	}

	public void Kill() 
	{
		isAlive = false;
		rigidBody.velocity = new Vector3(0, 0, 0);
	}

	void OnTriggerEnter(Collider collider) 
	{
 		onEventTriggerEnter(collider);
 	}

	// Update is called once per frame
	void Update () 
	{
		if (!isAlive) return;

		Vector3 position = transform.position;

		float speed = 0.03f;

		string direction = "none";

		if (Input.GetKey(KeyCode.W)) direction = "up";
		if (Input.GetKey(KeyCode.A)) direction = "left";
		if (Input.GetKey(KeyCode.S)) direction = "down";
		if (Input.GetKey(KeyCode.D)) direction = "right";

		switch (direction) 
		{
			case "up":
			rigidBody.velocity += new Vector3(0, speed, 0).normalized;
				break;
			case "left":
			rigidBody.velocity += new Vector3(-speed, 0, 0).normalized;
				break;
			case "down":
			rigidBody.velocity += new Vector3(0, -speed, 0).normalized;
				break;
			case "right":
			rigidBody.velocity += new Vector3(speed, 0, 0).normalized;
				break;
			case "none":
				rigidBody.velocity = new Vector3(0, 0, 0);
				break;
		}

		transform.position = position;
	}

}