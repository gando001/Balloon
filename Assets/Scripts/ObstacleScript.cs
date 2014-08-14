using UnityEngine;
using System.Collections;

public class ObstacleScript : MonoBehaviour {

	public GameObject part;
	public Sprite part1, part2, part3;

	private string nme;
	private Transform parent;
	private Transform balloon;
	private bool passed;

	// Use this for initialization
	void Start () 
	{
		// set the parent for the obstacle to the foreground
		this.transform.parent = GameObject.Find("Foreground").transform;

		balloon = GameObject.Find("Balloon").transform;
		passed = false;

		// set the parent for each obstacle part to the obstacle
		parent = GameObject.Find(name).transform;

		// name this obstacle group
		nme = "Obstacle-"+ConstantsScript.INDEX;
		this.transform.name = nme;
		ConstantsScript.INDEX += 1;
		rigidbody2D.velocity = new Vector2(0,ConstantsScript.VERTICAL_SPEED);
		
		generateParts();
	}

	void Update()
	{
		// destroy the obstacle when it goes off screen
		if (transform.position.y < transform.parent.position.y-1)
		{
			GameObject.Destroy(transform.gameObject);
		}

		// when the game is not over and this obstacle is below the balloon; the player has passed this obstacle
		if (!ConstantsScript.GAMEOVER && transform.position.y < balloon.position.y && !passed)
		{
			ConstantsScript.SCORE++;
			passed = true; // set a flag to only count the score once
		}
	}
	
	// generate the obstacle parts
	void generateParts()
	{	
		// the index of the gap
		int gap = Random.Range(0,ConstantsScript.OBSTACLE_PARTS);
		float x = this.transform.parent.position.x+1;

		for (int i=0; i<ConstantsScript.OBSTACLE_PARTS; i++)
		{
			if (gap != i)// && gap != (i+1) && gap != (i-1))
			{
				// create each obstacle part
				GameObject tmp = (GameObject)Instantiate(part, new Vector3(x,parent.transform.position.y,0), Quaternion.identity);
				tmp.transform.parent = parent;
				tmp.rigidbody2D.velocity = new Vector2(0,ConstantsScript.VERTICAL_SPEED);
				tmp.gameObject.name = "Obstacle_Part";

				int sprite = Random.Range(0,3);
				if (sprite == 0)
					tmp.GetComponent<SpriteRenderer>().sprite = part1;
				else if (sprite == 1)
					tmp.GetComponent<SpriteRenderer>().sprite = part2;
				else if (sprite == 2)
					tmp.GetComponent<SpriteRenderer>().sprite = part3;
			}
			x+=2;
		}
	}
}