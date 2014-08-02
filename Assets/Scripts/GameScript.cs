using UnityEngine;
using System.Collections;

public class GameScript : MonoBehaviour {

	public GameObject wall;

	// Use this for initialization
	void Start () 
	{
		createWalls();

		// show the banner ad
		Camera.main.GetComponent<GoogleMobileAdsScript>().ShowBanner();
	}
	
	// create the walls
	void createWalls()
	{
		Transform parent = GameObject.Find("Foreground").transform;
		float x = (float)parent.position.x;
		float y = (float)parent.position.y;
		float z = (float)parent.position.z;
		
		int cur_x = 0;
		int cur_y = 0;
		while (cur_y <= 16)
		{
			GameObject tmp = (GameObject)Instantiate(wall, new Vector3(cur_x+x,cur_y+y,0), Quaternion.identity);
			tmp.gameObject.name = "Wall";
			tmp.transform.parent = parent;

			tmp = (GameObject)Instantiate(wall, new Vector3(-(cur_x+x),cur_y+y,0), Quaternion.identity);
			tmp.gameObject.name = "Wall";
			tmp.transform.parent = parent;

			cur_y++;
		}
	}
}
