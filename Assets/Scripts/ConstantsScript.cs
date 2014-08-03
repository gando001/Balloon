using UnityEngine;
using System.Collections;

public class ConstantsScript : MonoBehaviour {

	public static bool REAL_DEVICE = false;

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
		MIN_RANGE = 40;
		INDEX = 1;
		DIFFICULTY_LEVEL = 5; // how many obstacles to pass before the obstacle range is decreased
	}
}
