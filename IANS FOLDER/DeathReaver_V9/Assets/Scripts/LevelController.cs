using UnityEngine;
using System.Collections;

//This function simply sets the current game level to the given value.
public class LevelController: MonoBehaviour 
{
	//Define Variables:
	//set game level in inspector view.
	public int set_GameLevel;


	// Use this for initialization
	void Awake () 
	{
		//Set Camera Control game level variable.
		CameraControl.game_Level = set_GameLevel;
	}

}
