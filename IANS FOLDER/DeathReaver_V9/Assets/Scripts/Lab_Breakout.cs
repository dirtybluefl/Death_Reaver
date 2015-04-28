using UnityEngine;
using System.Collections;

public class Lab_Breakout : MonoBehaviour 
{
	//Define Variables:
	//public GameObject player;
	public Player2 player_script;
	//Transform transformTest;
	public CameraControl cameraControl;

	// Use this for initialization
	void Start () 
	{
		//transformTest = GetComponent<Transform> ();
		//print (player_script.playerHasArmor);
	}
	
	// Update is called once per frame
	void Update () 
	{
		leave_Lab ();
	}

	void leave_Lab()
	{
		//print ("grr?");



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

	void loadLevel()
	{
		Application.LoadLevel (3); 
	}


}
