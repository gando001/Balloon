using UnityEngine;
using System.Collections;

public class PlaneScript : MonoBehaviour {

	private Vector3 postion;

	// Use this for initialization
	void Start () {
		postion = new Vector3(-13,6,2);
	}
	
	// Update is called once per frame
	void Update()
	{
		if (ConstantsScript.GAME_STARTED)
		{
			if (!ConstantsScript.GAMEOVER)
				rigidbody2D.velocity = new Vector2(ConstantsScript.PLANE_SPEED, 0);
			else 
			{
				// reset the position for a new game
				transform.position = postion;
				rigidbody2D.velocity = new Vector2(0, 0);
			}
		}
		
		// stop moving the buildings when it goes off screen
		if (transform.position.x > ConstantsScript.OFF_SCREEN_X)
		{
			transform.position = postion; // reset the planes position
		}
	}
}