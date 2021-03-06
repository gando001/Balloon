﻿using UnityEngine;
using System.Collections;

public class GameScript : MonoBehaviour {

	public GameObject wall;
	public GameObject obstacle;
	public GameObject balloon;
	public TextMesh score;
	public TextMesh started;
	public TextMesh score_text;
	public TextMesh score_text_shadow;
	public Sprite wall_right;
	public TextMesh best_score;

	// sounds
	public AudioClip balloon_pop;

	private bool generateObstacle;
	private int updateCounter;
	private bool levelIncreased;

	// Use this for initialization
	void Start () 
	{
		createWalls();

		generateObstacle = true;
		updateCounter = 0;
		levelIncreased = false;
	
		// show the banner ad
		this.GetComponent<GoogleMobileAdsScript>().ShowBanner();
	}

	void Update()
	{
		if (ConstantsScript.GAME_STARTED)
		{
			if (!ConstantsScript.GAMEOVER)
			{
				// create new obstacles when required
				if(generateObstacle)
				{
					// create a new obstacle
					generateObstacle = false;
					Invoke("GenerateNewObstacle",0);
				}
				else
					updateCounter++;
				
				if(updateCounter >= ConstantsScript.RANGE)
				{
					// time to create a new obstacle
					generateObstacle = true;
					updateCounter = 0;
				}
			}
			else
				resetGame(); // game is over so reset and show the start message

			score.text = ConstantsScript.SCORE+"";
			if (ConstantsScript.SCORE > 0 && !levelIncreased && (ConstantsScript.SCORE % ConstantsScript.DIFFICULTY_LEVEL == 0))
			{
				// increase the difficulty by reducing the range value
				ConstantsScript.RANGE = Mathf.Max((ConstantsScript.RANGE-ConstantsScript.DIFFICULTY), ConstantsScript.MIN_RANGE);
				levelIncreased = true; // only increase the level once
			}
			else if (ConstantsScript.SCORE > 0 && ConstantsScript.SCORE % ConstantsScript.DIFFICULTY_LEVEL != 0)
				levelIncreased = false;
		}
		else
		{
			// wait until user has started the game
			if (ConstantsScript.REAL_DEVICE)
			{
				// user input has finished touching the screen
				if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended)
					startGame();
			}
			else
			{
				if (Input.GetAxis ("Horizontal") != 0)
					startGame();
			}
		}

		if (Input.GetKeyDown(KeyCode.Escape))
		{
			// user pressed the go back button
			Application.Quit();
		}

		// check for a new best score
		if (ConstantsScript.SCORE > PlayerPrefs.GetInt(ConstantsScript.BEST))
			PlayerPrefs.SetInt(ConstantsScript.BEST, ConstantsScript.SCORE);

		// display/update the best score
		if (PlayerPrefs.HasKey(ConstantsScript.BEST))
			best_score.text = "best: "+PlayerPrefs.GetInt(ConstantsScript.BEST);
		else
			best_score.text = "best: 0";

		/*if (!ConstantsScript.REAL_DEVICE && Input.GetKeyDown("space"))
		{
			print ("Screenshot");
			Application.CaptureScreenshot("/Users/Kunals-iMac/Dropbox/Apps/Android/SIKK Balloon/Market Assets/Tablet/screenshot.png");
		}*/
	}
	
	void GenerateNewObstacle()
	{
		Instantiate(obstacle);
	}

	void startGame()
	{
		ConstantsScript.GAME_STARTED = true;
		
		// show the balloon
		balloon.SetActive(true);

		// (re)centre the balloon
		balloon.GetComponent<BalloonScript>().resetBalloon();

		// show the HUD
		score.gameObject.SetActive(true);

		// hide the start message
		started.gameObject.SetActive(false);

		// hide the score message
		score_text.gameObject.SetActive(false);
		score_text_shadow.gameObject.SetActive(false);
	}

	void resetGame()
	{
		// pop the balloon
		audio.PlayOneShot(balloon_pop);

		// display the score to the user
		score_text.text = "score: "+ConstantsScript.SCORE;
		score_text_shadow.text = "score: "+ConstantsScript.SCORE;

		ConstantsScript.resetGame();

		// destroy all obstacle groups and walls
		foreach(GameObject obj in GameObject.FindGameObjectsWithTag("Obstacle_Group"))
		{
			GameObject.Destroy(obj);
		}
		
		// hide the balloon
		balloon.SetActive(false);

		// hide the HUD
		score.gameObject.SetActive(false);

		// show the start message
		started.gameObject.SetActive(true);

		// show the score message
		score_text.gameObject.SetActive(true);
		score_text_shadow.gameObject.SetActive(true);

		// create the walls
		createWalls();
	}
	
	// create the walls
	void createWalls()
	{
		Transform parent = GameObject.Find("Foreground").transform;
		float x = (float)parent.position.x-0.5f;
		float y = (float)parent.position.y;

		int cur_y = 0;
		while (cur_y < 19)
		{
			// create each side of the wall
			// left
			GameObject tmp = (GameObject)Instantiate(wall, new Vector3(x,cur_y+y,-2), Quaternion.identity);
			tmp.gameObject.name = "Wall";
			tmp.transform.parent = parent;

			// right
			tmp = (GameObject)Instantiate(wall, new Vector3(-x,cur_y+y,-2), Quaternion.identity);
			tmp.gameObject.name = "Wall";
			tmp.transform.parent = parent;
			tmp.GetComponent<SpriteRenderer>().sprite = wall_right;
			tmp.GetComponent<BoxCollider2D>().center = new Vector2(-tmp.GetComponent<BoxCollider2D>().center.x, tmp.GetComponent<BoxCollider2D>().center.y); // reverse the collider x co-ordinate

			cur_y++;
		}
	}
}
