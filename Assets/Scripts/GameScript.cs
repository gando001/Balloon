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
		int x = -16;
		int y = 8;
		while (y >= -6)
		{
			GameObject tmp = (GameObject)Instantiate(wall, new Vector3(x,y,0), Quaternion.identity);
			tmp.gameObject.name = "Wall";
			tmp = (GameObject)Instantiate(wall, new Vector3(-x,y,0), Quaternion.identity);
			tmp.gameObject.name = "Wall";
			y--;
		}
	}
}
