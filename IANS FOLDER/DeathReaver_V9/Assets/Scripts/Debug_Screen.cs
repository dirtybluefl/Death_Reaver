using UnityEngine;
using System.Collections;

public class Debug_Screen : MonoBehaviour 
{
	//Define variables:
	public CanvasGroup cg;



	// Use this for initialization
	void Start () 
	{
		//CanvasGroup cg = this.GetComponent<CanvasGroup>();
	}
	
	// Update is called once per frame
	void Update () 
	{

		/*
			if (Input.GetKeyDown ("d")) 
			{
				print("d key was pressed FOR DEBUGGING to toggle off");
				
				//toggle back off:
				if (CameraControl.debug_ScreenActive == true) 
				{
					print("debug off");
					CameraControl.debug_ScreenActive = false;
					CameraControl.game_Paused = false;
					Time.timeScale = 1;
				}
				
			}
		*/






		//Shows character screen:
		if(CameraControl.debug_ScreenActive == true)
		{
			//print("debug screen active");
			//CanvasGroup cg = this.GetComponent<CanvasGroup>();
			cg.blocksRaycasts = true;
			cg.interactable= true;
			cg.alpha = 1;
			//print ("show character screen");


		}

		//Hides character screen:
		else if(CameraControl.debug_ScreenActive == false)
		{
			//print("debug screen NOT active");
			//CanvasGroup cg = this.GetComponent<CanvasGroup>();
			cg.blocksRaycasts = false;
			cg.interactable= false;
			cg.alpha = 0;
			//print ("DO NOT show character screen");
		}
	}
}
