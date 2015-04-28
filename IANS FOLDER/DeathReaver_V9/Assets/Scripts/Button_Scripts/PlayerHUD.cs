using UnityEngine;
using System.Collections;

public class PlayerHUD : MonoBehaviour 
{
	//Define variables:
	public CanvasGroup cg;

	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		//hide when other character screens are up:
		hideHUD ();
	}


	void OnMouseEnter() 
	{
		print ("OVER GUI!!!!");
		//Player2.over_GUI = true;
	}

	void OnMouseExit() 
	{
		print ("NOT OVER GUI");
		//Player2.over_GUI = false;
	}

	void hideHUD() 
	{

		//Shows character screen:
		if(CameraControl.pause_ScreenActive == true)
		{
			//CanvasGroup cg = this.GetComponent<CanvasGroup>();
			cg.alpha = 0;
			//print ("show character screen");
		}


		else if(CameraControl.character_ScreenActive == true)
		{
			//CanvasGroup cg = this.GetComponent<CanvasGroup>();
			cg.alpha = 0;
			//print ("DO NOT show character screen");
		}

		else if(CameraControl.death_ScreenActive == true)
		{
			//CanvasGroup cg = this.GetComponent<CanvasGroup>();
			cg.alpha = 0;
			//print ("DO NOT show character screen");
		}

		else if(CameraControl.debug_ScreenActive == true)
		{
			//CanvasGroup cg = this.GetComponent<CanvasGroup>();
			cg.alpha = 0;
			//print ("DO NOT show character screen");
		}


		
		//Otherwise, show player HUD:
		else
		{
			//CanvasGroup cg = this.GetComponent<CanvasGroup>();
			cg.alpha = 1;
			//print ("DO NOT show character screen");
		}






















	}
}
