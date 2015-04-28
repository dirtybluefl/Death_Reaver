using UnityEngine;
using System.Collections;

public class CameraControl : MonoBehaviour 
{

	/*Side Notes:
	Initially zoomed out, invoke after set amount of time to zoom in and start tracking player with fixed rotation.
	*/

	//Define Variables:


	public static bool debug_Mode = true;

	public static CameraControl camera_Control;
	public TransitionCamera transitionCamera;
	//public GameObject camera_ControlObject;
	public static bool game_Paused = true;
	//public static bool camera_Position = false;
	//public static bool initial_Pause = true;
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



		//reset_Variables ();

		if(CameraControl.game_Level == 1)
		{
			game_Paused = true;
			Player2.isRolling = false;
			reset_Variables ();
			transitionCamera.activate_Transition();
		}

		else if(CameraControl.game_Level == 2)
		{
			game_Paused = true;
			Player2.isRolling = false;
			reset_Variables ();
			transitionCamera.activate_Transition();
		}


		else if(CameraControl.game_Level == 3)
		{
			game_Paused = true;
			Player2.isRolling = false;
			load_Stats();
			transitionCamera.activate_Transition();
		}

		else if(CameraControl.game_Level == 4)
		{
			//load saved game stats instead.
			game_Paused = true;
			Player2.isRolling = false;
			load_Stats();
			transitionCamera.activate_Transition();
		}


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







		//Invoke("enable_Game", 1);	//seconds

	}
	
	// Update is called once per frame
	void Update () 
	{
		//print (game_Paused);

		if(game_Paused == false)
		{
			track_Player();
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
			Player2.health = 0;
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
		Player_SoulBar.new_MaxSouls = Player2.level1_Unlock;

	
		//game_Paused = true;
		//camera_Position = false;
		//initial_Pause = true;
		character_ScreenActive = false;
		pause_ScreenActive = false;
		debug_ScreenActive = false;
		death_ScreenActive = false;
		//print ("Death screen active: " + death_ScreenActive);

	}


	//Functions controls how to handle Cmaera Player Tracking based on what scene/level player is on.
	public void track_Player()
	{
		//print ("Game level: " + game_Level);


		//Survival Mode:
		if(game_Level == 1)
		{
			//Lock rotation:transform.rotation = rotation;
			this.transform.position = new Vector3(target.transform.position.x + 0, target.transform.position.y + 19, target.transform.position.z + 18);
		}

		else if(game_Level == 2)
		{
			//Lock rotation:transform.rotation = rotation;
			this.transform.position = new Vector3(target.transform.position.x + -11.24f, target.transform.position.y + 18.171469461f, target.transform.position.z + -13.46f);
			this.transform.eulerAngles = new Vector3(46.00002f, 40f, 0f);
			/*OLD POSITION:
			this.transform.position = new Vector3(target.transform.position.x + -7.60159f, target.transform.position.y + 7.942858461f, target.transform.position.z + -4.11175f);
			this.transform.eulerAngles = new Vector3(40.08512f, 75.73247f, -0.002153715f); */
		}

		else if(game_Level == 3)
		{
			//Lock rotation:transform.rotation = rotation;
			this.transform.position = new Vector3(target.transform.position.x + -11.24f, target.transform.position.y + 18.171469461f, target.transform.position.z + -13.46f);
			this.transform.eulerAngles = new Vector3(46.00002f, 40f, 0f);
			/*OLD POSITION:
			this.transform.position = new Vector3(target.transform.position.x + -7.60159f, target.transform.position.y + 7.942858461f, target.transform.position.z + -4.11175f);
			this.transform.eulerAngles = new Vector3(40.08512f, 75.73247f, -0.002153715f); */
		}

		else if(game_Level == 4)
		{
			//Lock rotation:transform.rotation = rotation;
			this.transform.position = new Vector3(target.transform.position.x + 0, target.transform.position.y + 19, target.transform.position.z + 18);
		}


	}


	//SAVE PLAYER STATS, will be saved upon leaving museum interior and will be loaded at start of museum exterior to make sure player 
	// progress is saved.
	public void save_Stats()
	{
		print ("SAVING STATS: ....");

		Player2.save_Health = Player2.health;												//Save Player's Current Health.		
		//Player2.save_Max_Health = Player2.max_Health;										//Save Player's Current Max Health.	
		Player2.save_Current_Souls = Player_SoulBar.current_Souls;							//Save Player's Current Souls Collected.	

		Player2.save_Chose_WeaponSpecialization = Player2.chose_WeaponSpecialization;		//Save Bool Whether or not player has a weapon spec.	
		Player2.save_Chose_Tier1Talent = Player2.chose_Tier1Talent;							//Save Bool Whether or not player has a talent 1 chosen.
		Player2.save_Chose_Tier2Talent = Player2.chose_Tier2Talent;							//Save Bool Whether or not player has a talent 2 chosen.
		Player2.save_Chose_Tier3Talent = Player2.chose_Tier3Talent;							//Save Bool Whether or not player has a talent 3 chosen.
			

		Player2.save_Weapon_Specialization = Player2.weapon_Specialization;	
		Player2.save_Tier1_Talent = Player2.tier1_Talent;	
		Player2.save_Tier2_Talent = Player2.tier2_Talent;	
		Player2.save_Tier3_Talent = Player2.tier3_Talent;	

		print ("Saved Health: " + Player2.save_Health);
		print ("Saved Souls: " + Player2.save_Current_Souls);
		print ("Saved Chosen Weapon: " + Player2.save_Chose_WeaponSpecialization);
		print ("Saved Chosen Talent1: " + Player2.save_Chose_Tier1Talent);
		print ("Saved Chosen Talent2: " + Player2.save_Chose_Tier2Talent);
		print ("Saved Chosen Talent3: " + Player2.save_Chose_Tier3Talent);
		print ("Saved Chosen Weapon: " + Player2.save_Chose_WeaponSpecialization);
		print ("Saved Chosen Talent1: " + Player2.save_Chose_Tier1Talent);
		print ("Saved Chosen Talent2: " + Player2.save_Chose_Tier2Talent);
		print ("Saved Chosen Talent3: " + Player2.save_Chose_Tier3Talent);

		print ("Saved Weapon Spec Choice: " + Player2.save_Weapon_Specialization);
		print ("Saved Talent1 Choice: " + Player2.save_Tier1_Talent);
		print ("Saved Talent2 Choice: " + Player2.save_Tier2_Talent);
		print ("Saved Talent3 Choice: " + Player2.save_Tier3_Talent);

		//Print Debug to show stats were saved correctly:
		//Save status of ability cooldowns???? 
	
	}
	
	
	//load PLAYER STATS, will be loaded at start of Museum Exterior scene to make sure player progress is continued.
	public void load_Stats()
	{
		Time.timeScale = 1;
		//make sure these screen overlays are hidden on new scene load:
		character_ScreenActive = false;
		pause_ScreenActive = false;
		debug_ScreenActive = false;
		death_ScreenActive = false;
		
		print ("LOADING STATS: ....");
		
		Player2.health = Player2.save_Health;												//Save Player's Current Health.		
		//Player2.save_Max_Health = Player2.max_Health;										//Save Player's Current Max Health.	
		Player_SoulBar.current_Souls = Player2.save_Current_Souls;							//Save Player's Current Souls Collected.	
		
		Player2.chose_WeaponSpecialization = Player2.save_Chose_WeaponSpecialization;		//Save Bool Whether or not player has a weapon spec.	
		Player2.chose_Tier1Talent = Player2.save_Chose_Tier1Talent;							//Save Bool Whether or not player has a talent 1 chosen.
		Player2.chose_Tier2Talent = Player2.save_Chose_Tier2Talent;							//Save Bool Whether or not player has a talent 2 chosen.
		Player2.chose_Tier3Talent = Player2.save_Chose_Tier3Talent;							//Save Bool Whether or not player has a talent 3 chosen.
		
		
		Player2.weapon_Specialization = Player2.save_Weapon_Specialization;	
		Player2.tier1_Talent = Player2.save_Tier1_Talent;	
		Player2.tier2_Talent = Player2.save_Tier2_Talent;	
		Player2.tier3_Talent = Player2.save_Tier3_Talent;	
		
		
		print ("LOADED Health: " + Player2.save_Health);
		print ("LOADED Souls: " + Player2.save_Current_Souls);
		print ("LOADED Chosen Weapon: " + Player2.save_Chose_WeaponSpecialization);
		print ("LOADED Chosen Talent1: " + Player2.save_Chose_Tier1Talent);
		print ("LOADED Chosen Talent2: " + Player2.save_Chose_Tier2Talent);
		print ("LOADED Chosen Talent3: " + Player2.save_Chose_Tier3Talent);
		print ("LOADED Chosen Weapon: " + Player2.save_Chose_WeaponSpecialization);
		print ("LOADED Chosen Talent1: " + Player2.save_Chose_Tier1Talent);
		print ("LOADED Chosen Talent2: " + Player2.save_Chose_Tier2Talent);
		print ("LOADED Chosen Talent3: " + Player2.save_Chose_Tier3Talent);
		
		print ("LOADED Weapon Spec Choice: " + Player2.save_Weapon_Specialization);
		print ("LOADED Talent1 Choice: " + Player2.save_Tier1_Talent);
		print ("LOADED Talent2 Choice: " + Player2.save_Tier2_Talent);
		print ("LOADED Talent3 Choice: " + Player2.save_Tier3_Talent);
		
		
	}














}
