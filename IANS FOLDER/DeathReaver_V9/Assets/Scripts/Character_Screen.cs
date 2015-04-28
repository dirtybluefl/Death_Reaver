using UnityEngine;
using System.Collections;

public class Character_Screen : MonoBehaviour 
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
		//Shows character screen:
		if(CameraControl.character_ScreenActive == true)
		{
			//CanvasGroup cg = this.GetComponent<CanvasGroup>();
			cg.blocksRaycasts = true;
			cg.interactable= true;
			cg.alpha = 1;
			//print ("show character screen");


		}

		//Hides character screen:
		else if(CameraControl.character_ScreenActive == false)
		{
			//CanvasGroup cg = this.GetComponent<CanvasGroup>();
			cg.blocksRaycasts = false;
			cg.interactable= false;
			cg.alpha = 0;
			//print ("DO NOT show character screen");
		}
	}
}
