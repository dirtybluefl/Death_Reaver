using UnityEngine;
using System.Collections;

public class Restart_Button : MonoBehaviour 
{
	//Define Variables:
	//GameObject cameraControlObject = CameraControl.camera_ControlObject;
	public CameraControl cameraControl;

	// Use this for initialization
	void Start () 
	{
		//cameraControl = CameraControl.camera_Control;
		//GameObject cameraControlObject = GameObject.FindWithTag("MainCamera");

	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}
	
	//RESETS all of the chosen talents/skills when clicked.
	//OnMouseClick:
	public void MouseClick()
	{
		//Museum Exterior has player progress, will want to load saved stats instead of starting over.
		if(CameraControl.game_Level == 3)
		{
			cameraControl.load_Stats();
		}

		//All other circumstances should only require a full reset of player stats.
		else
		{
			cameraControl.reset_Variables ();
		}


		//cameraControl.reset_Variables ();
		Application.LoadLevel (Application.loadedLevelName);
		
	}   
	
	
	
}
