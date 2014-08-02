using UnityEngine;
using System.Collections;

public class GenerateObstaclesScript : MonoBehaviour {

	public GameObject obstacles;

	private bool gen = true;
	private int updateCounter = 0;

	// Use this for initialization
	void Start()
	{
	}

	void Update()
	{
		if (!ConstantsScript.GAMEOVER)
		{
			// create new obstacles when required
			if(gen)
			{
				// create a new obstacle
				gen = false;
				Invoke("GenerateNewObstacle",0);
			}
			else
				updateCounter++;

			if(updateCounter >= ConstantsScript.RANGE)
			{
				// time to create a new obstacle
				gen = true;
				updateCounter = 0;
			}
		}
	}

	void GenerateNewObstacle()
	{
		Instantiate(obstacles);
	}
}