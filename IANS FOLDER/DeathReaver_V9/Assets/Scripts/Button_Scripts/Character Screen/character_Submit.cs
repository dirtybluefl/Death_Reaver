using UnityEngine;
using System.Collections;

public class character_Submit : MonoBehaviour 
{
	//Define Variables:
	public Player2 player_script;
	public CameraControl cameraControl;



	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}


	void resume_Play()
	{
		print("game play resumed called function");
		CameraControl.game_Paused = false;
		CameraControl.character_ScreenActive = false;
		//Time.timeScale = 1;
	}


	//When SUBMIT button is clicked, closes character screen and resumes gameplay.
	//OnMouseClick:
	public void MouseClick()
	{
		print ("button was clicked...");
		if(CameraControl.character_ScreenActive == true)
		{
			player_script.check_WeaponSpecialization();
			player_script.check_TalentTier1();
			print ("invoking?");
			Time.timeScale = 1;
			Invoke("resume_Play", .01f);	//use invoke to disable mouse feedback just long enough to resume game. 

			if(CameraControl.game_Level == 2)
			{
				if (Player2.chose_WeaponSpecialization == true)
				{
					
					//application load level.
					print ("leaving Lab");
					cameraControl.save_Stats();
					loadLevel();
					//Loads the Scene plugged into scene slot (3)
					//Invoke("loadLevel", 2);
					
				}
			}





			//(previously player would move to location of where submit button was clicked.
		}	


	}   


	void loadLevel()
	{
		Application.LoadLevel (3); 
	}




}
