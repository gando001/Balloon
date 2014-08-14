using UnityEngine;
using System.Collections;

public class BalloonScript : MonoBehaviour {

	private float x;

	// Use this for initialization
	void Start () {
		x = transform.position.x; // store the starting x location
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (ConstantsScript.GAME_STARTED && !ConstantsScript.GAMEOVER)
		{
			if (ConstantsScript.REAL_DEVICE)
			{
				// move the balloon along the x axis as the device is moved
				transform.Translate(Input.acceleration.x*ConstantsScript.INPUT_SENSITIVITY, 0, 0);
			}
			else
			{
				// keyboard input
				// Use for testing in Unity not on device
				// get the keyboard values and calculate the movement
				transform.Translate(Input.GetAxis ("Horizontal")*ConstantsScript.INPUT_SENSITIVITY,0,0);
			}
		}
	}

	void OnTriggerEnter2D(Collider2D otherCollider)
	{
		// OnTriggerEnter2D(Collider2D otherCollider) is invoked when another 
		// collider marked as a "Trigger" is touching this object collider.

		// determine the other collider
		if (otherCollider.gameObject.name == "Obstacle_Part" || otherCollider.gameObject.name == "Wall")
		{	
			ConstantsScript.GAMEOVER = true;

			// pop the balloon
		}
	}

	public void resetBalloon()
	{
		// centre the balloon
		transform.position = new Vector3(x, transform.position.y, transform.position.z);
	}
}
