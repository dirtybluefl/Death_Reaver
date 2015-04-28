using UnityEngine;
using System.Collections;

public class CameraControl2 : MonoBehaviour 
{

	/*Side Notes:
	Initially zoomed out, invoke after set amount of time to zoom in and start tracking player with fixed rotation.
	*/

	//Define Variables:


	public static bool debug_Mode = true;

	public static CameraControl2 camera_Control;
	//public GameObject camera_ControlObject;
	public static bool game_Paused = true;
	public static bool camera_Position = false;
	public static bool initial_Pause = true;
	public static bool character_ScreenActive = false;
	public static bool pause_ScreenActive = false;
	public static bool debug_ScreenActive = false;
	public static bool death_ScreenActive = false;
	//public GameObject player;
	public float lockPos = 0;
	//Transform target;
	float distance;
	//Camera follow experiment:
	public GameObject target;
	public int xOffset = 0;
	public int yOffset = 19;
	public int zOffset = -37;
	//Transition to position overtime:
	public Transform startMarker;
	public Transform endMarker;
	public float speed = 1.0F;
	private float startTime;
	private float journeyLength;
	//Track game level:
	public static int game_Level = 0;
	public Player2 player;
	//public GameObject main_Camera;

	// Use this for initialization
	void Start () 
	{
		reset_Variables ();

		if(CameraControl.game_Level == 1)
		{
			reset_Variables ();
		}


		//DEBUG:
		game_Level = 1;

		//Initialize:
		camera_Control = this;

		target = GameObject.Find("Player");

		//Show if game is in debug mode or not:
		if(debug_Mode == true)
		{
			print ("GAME IS IN DEBUG MODE, BE WARNED");
		}


		//main_Camera = GameObject.Find("Main Camera");

		//Add camera as child object to player object:
		//this.transform.parent = player.transform;

		//Transition setup:
		startTime = Time.time;
		journeyLength = Vector3.Distance(startMarker.position, endMarker.position);
		//startMarker = (transform.position.0, transform.position.0, transform.position.0);
		//endMarker = new Vector3(x, y, z);


		//run one time:


		//Invoke("enable_Game", 4);	//seconds
		Invoke("transition_Camera", 2);	//seconds
	}
	
	// Update is called once per frame
	void Update () 
	{
		
		
		
		if(initial_Pause == false)
		{
			//Debug.Log ("Initial Pause is false");
			if (camera_Position == false) 
			{
				//Debug.Log ("Not yet in position");
				//transition camera to new location over time:
				float distCovered = (Time.time - startTime) * speed;
				float fracJourney = distCovered / journeyLength;
				transform.position = Vector3.Lerp(startMarker.position, endMarker.position, fracJourney);
				
				
				
				if(transform.position == endMarker.position)
				{
					//Debug.Log ("Target reached");
					camera_Position = true;
					game_Paused = false;
				}
			}
		}
		
		
		
		
		
		if(game_Paused == false)
		{
			//Lock rotation:transform.rotation = rotation;
			//this.transform.position = new Vector3(target.transform.position.x + 0, target.transform.position.y + 19, target.transform.position.z + 18);

			float distCovered = (Time.time - startTime) * speed;
			float fracJourney = distCovered / journeyLength;
			transform.position = Vector3.Lerp(startMarker.position, endMarker.position, fracJourney);
			toggle_CharacterScreen();
			toggle_PauseScreen();
			toggle_DebugScreen();
			toggle_DeathScreen();
		}
		

		
		
		
	}



	public void enable_Game()
	{
		Debug.Log ("Game no longer paused");
		game_Paused = false;
	}

	public void transition_Camera()
	{
		//Debug.Log ("transitioning camera position");
		initial_Pause = false;

	}

	public void toggle_CharacterScreen()
	{
		if (Input.GetKeyDown ("c")) 
		{
			print("c key was pressed");

			//If character screen is not already open...
			if (character_ScreenActive == false) 
			{
				character_ScreenActive = true;
				game_Paused = true;
				Time.timeScale = 0;
			}

			/* replace with submit button / migrate code. 
			//toggle back off:
			else if(character_ScreenActive == true)
			{
				character_ScreenActive = false;
				game_Paused = false;
				Time.timeScale = 1;
			}
			*/


		}
			
		
	}

	public void toggle_PauseScreen()
	{
		if (Input.GetKeyDown ("p")) 
		{
			print("p key was pressed");
			
			//If character screen is not already open...
			if (pause_ScreenActive == false) 
			{
				pause_ScreenActive = true;
				game_Paused = true;
				Time.timeScale = 0;
			}
		
		}
	}



	public void toggle_DeathScreen()
	{
		if (Player2.health <= 0) 
		{
			print("GAME OVER");
			
			//If character screen is not already open...

			if (death_ScreenActive == false) 
			{
				death_ScreenActive = true;
				game_Paused = true;
				Time.timeScale = 0;
			}



			/* replace with submit button / migrate code. 
			//toggle back off:
			else if(character_ScreenActive == true)
			{
				character_ScreenActive = false;
				game_Paused = false;
				Time.timeScale = 1;
			}
			*/
			
			
		}
		
		
	}

	public void toggle_DebugScreen()
	{
		if (Input.GetKeyDown ("d")) 
		{
			print("d key was pressed FOR DEBUGGING");
			
			//If character screen is not already open...
			if (debug_ScreenActive == false) 
			{
				//print("debug on");
				debug_ScreenActive = true;
				game_Paused = true;
				Time.timeScale = 0;
			}
		}
	}



	//Function to reset Static Variables to start a new level fresh:
	public void reset_Variables()
	{

		print ("static variables reset");

		Time.timeScale = 1;
		Player2.health = 300f;				//Player Health Value.
		Player2.max_Health = 300f;

		//player.check_WeaponSpecialization ();


		Player2.chose_WeaponSpecialization = false;
		Player2.chose_Tier1Talent = false;
		Player2.chose_Tier2Talent = false;
		Player2.chose_Tier3Talent = false;

		Player2.weapon_Specialization = 0;
		Player2.tier1_Talent = 0;
		Player2.tier2_Talent = 0;
		Player2.tier3_Talent = 0;

		Player_SoulBar.current_Souls = 0;
		Player_SoulBar.new_MaxSouls = 0;

	
		game_Paused = true;
		camera_Position = false;
		initial_Pause = true;
		character_ScreenActive = false;
		pause_ScreenActive = false;
		debug_ScreenActive = false;
		death_ScreenActive = false;
		//print ("Death screen active: " + death_ScreenActive);

	}


}
