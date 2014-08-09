using UnityEngine;
using System.Collections;

public class BuildingScript : MonoBehaviour {

	// Use this for initialization
	void Start () {

	}

	void Update()
	{
		if (ConstantsScript.GAME_STARTED)
		{
			if (!ConstantsScript.GAMEOVER)
				rigidbody2D.velocity = new Vector2(0, ConstantsScript.BUILDING_SPEED);
			else 
			{
				// reset the position for a new game
				transform.position = new Vector3(0,1.4f,2);
				rigidbody2D.velocity = new Vector2(0, 0);
			}
		}

		// stop moving the buildings when it goes off screen
		if (transform.position.y < ConstantsScript.OFF_SCREEN)
		{
			rigidbody2D.velocity = new Vector2(0, 0);
		}

	}
}
