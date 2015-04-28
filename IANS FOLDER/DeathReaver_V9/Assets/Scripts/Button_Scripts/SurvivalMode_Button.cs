using UnityEngine;
using System.Collections;

//Function is called when survival mode button is clicked on the main menu, and will change scenes to start the survival mode gameplay.
public class SurvivalMode_Button : MonoBehaviour 
{

	// Use this for initialization
	void Start () 
	{
		//Debug.Log ("Survival mode activated on click!");
	}
	
	// Update is called once per frame
	void Update () 
	{
		//Determine if button is clicked, then activate function:

	}


	//OnMouseClick:
	public void MouseClick()
	{
		// this object was clicked - do something
		Debug.Log ("Survival mode activated on click!");
		//change scene:
		CameraControl.game_Level = 1;
		Application.LoadLevel ("HARVEST_MODE_WORKING"); 

	}   






}
