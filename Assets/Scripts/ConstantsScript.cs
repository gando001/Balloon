using UnityEngine;
using System.Collections;

public class ConstantsScript : MonoBehaviour {

	public static bool REAL_DEVICE = false;

	public static int OFF_SCREEN;

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

	// background
	public static float BUILDING_SPEED;

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
		INPUT_SENSITIVITY = 5f;
		
		// obstacles
		VERTICAL_SPEED = -5;
		MAX_RANGE = 170;
		RANGE = MAX_RANGE;
		MIN_RANGE = 50;
		INDEX = 1;
		DIFFICULTY_LEVEL = 3; // how many obstacles to pass before the obstacle range is decreased
		DIFFICULTY = 15; // how much to reduce the obstacle range by
		OBSTACLE_PARTS = 12;
		STARTING_Y = 18; // y value where the top wall is

		// background
		BUILDING_SPEED = -0.1f; // how much to move the buildings

		OFF_SCREEN = -12; // value to determine whether and object is no longer visible
	}
}
