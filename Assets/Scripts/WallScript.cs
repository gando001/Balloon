using UnityEngine;
using System.Collections;

public class WallScript : MonoBehaviour {
	
	// Use this for initialization
	void Start () 
	{
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (ConstantsScript.GAME_STARTED)
		{
			if (!ConstantsScript.GAMEOVER)
				rigidbody2D.velocity = new Vector2(0, ConstantsScript.VERTICAL_SPEED);
		}

		// move the wall to the top of the wall stack when it goes off screen
		if (transform.position.y < transform.parent.position.y-1)
		{
			transform.position = new Vector3(transform.position.x, transform.parent.position.y+ConstantsScript.STARTING_Y, transform.position.z);
		}
	}
}
