using UnityEngine;
using System.Collections;

public class MoveObstacleScript : MonoBehaviour {

	public GameObject part;

	private string nme;
	private Transform parent;

	// Use this for initialization
	void Start () 
	{
		// name this obstacle
		nme = "Obstacle-"+ConstantsScript.INDEX;
		this.transform.name = nme;
		ConstantsScript.INDEX += 1;

		this.transform.parent = GameObject.Find("Foreground").transform;
		
		parent = GameObject.Find(name).transform;
		generateParts();
	}
	
	// generate the obstacle parts
	void generateParts()
	{	
		// the index of the gap
		int parts = 27;
		int gap = Random.Range(2,parts-1);
		float x = this.transform.parent.position.x-1;
		for (int i=0; i<parts; i++)
		{
			if (gap != i && gap != (i+1) && gap != (i-1))
			{
				GameObject tmp = (GameObject)Instantiate(part, new Vector3(x,parent.transform.position.y,0), Quaternion.identity);
				tmp.transform.parent = parent;
				tmp.rigidbody2D.velocity = new Vector2(0,ConstantsScript.VERTICAL_SPEED);
				tmp.gameObject.name = "Obstacle_Part";
			}
			x++;
		}
	}
}