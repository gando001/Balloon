﻿using UnityEngine;
using System.Collections;

public class ConstantsScript : MonoBehaviour {

	public static bool REAL_DEVICE = true;

	public static int OFF_SCREEN_X;
	public static int OFF_SCREEN_Y;

	// game logic
	public static bool GAMEOVER;
	public static bool GAME_STARTED;
	public static int SCORE;

	// user input
	public static float INPUT_SENSITIVITY;

	// obstacles
	public static float VERTICAL_SPEED;
	public static int MAX_RANGE;
	public static int RANGE;
	public static int MIN_RANGE;
	public static int INDEX;
	public static int DIFFICULTY_LEVEL;
	public static int DIFFICULTY;
	public static int OBSTACLE_PARTS;
	public static int STARTING_Y;
	public static int MIN_OBSTACLE_GAP;
	public static int MAX_OBSTACLE_GAP;

	// background
	public static float BUILDING_SPEED;
	public static int WALLS;
	public static float PLANE_SPEED;

	// best score
	public static string BEST = "BEST";

	// Use this for initialization
	void Start () 
	{
		resetGame();
	}

	public static void resetGame()
	{
		// game logic
		GAMEOVER = false;
		GAME_STARTED = false;
		SCORE = 0;
		
		// user input
		INPUT_SENSITIVITY = 3.5f;
		
		// obstacles
		VERTICAL_SPEED = -5f;
		MAX_RANGE = 170;
		RANGE = MAX_RANGE;
		MIN_RANGE = 50;
		INDEX = 1;
		DIFFICULTY_LEVEL = 3; // how many obstacles to pass before the obstacle range is decreased
		DIFFICULTY = 15; // how much to reduce the obstacle range by
		OBSTACLE_PARTS = 12;
		STARTING_Y = 18; // y value where the top wall is
		MIN_OBSTACLE_GAP = 1; // the minimum number of gaps in the obstacle
		MAX_OBSTACLE_GAP = 3; // the maximum number of gaps in the obstacle

		// background
		BUILDING_SPEED = -0.1f; // how much to move the buildings
		WALLS = 11; // the number of walls per side
		PLANE_SPEED = 1; // how much to move the planes
		OFF_SCREEN_Y = -12; // value to determine whether an object is no longer visible vertically
		OFF_SCREEN_X = 25; // value to determine whether an object is no longer visible horizontally
	}
}
