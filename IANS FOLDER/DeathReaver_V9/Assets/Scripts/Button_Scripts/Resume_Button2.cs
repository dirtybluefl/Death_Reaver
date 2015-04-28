using UnityEngine;
using System.Collections;

public class Resume_Button2 : MonoBehaviour 
{




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
		CameraControl.debug_ScreenActive = false;
		CameraControl.game_Paused = false;
		Time.timeScale = 1;
		
	}   
	
	
	
}
