using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class tier1_Talent1 : MonoBehaviour 
{
	//Define Variables:
	CanvasGroup cg;
	public Tooltip_Cleave_Talent tooltip_Cleave_Talent;	//Provides direct access to the ToolTip_Mace script.
	public Player2 player;

	// Use this for initialization
	void Start () 
	{
		//Only perform when game is in debug mode:
		if(CameraControl.debug_Mode == true)
		{
			//DEBUG:
			//Player_SoulBar.current_Souls = 5;
		}



		cg = this.GetComponent<CanvasGroup>();
		//clickButton.interactable = false;
	}
	
	// Update is called once per frame
	void Update () 
	{
		//Change Appearance based on State:
		if(Player_SoulBar.current_Souls >= Player2.level2_Unlock)
		{
			if(Player2.chose_Tier1Talent == false)
			{
				cg.interactable= true;
			}

			else if(Player2.chose_Tier1Talent == true)
			{
				cg.interactable= false;
			}
		}

		else
		{
			cg.interactable= false;
		}



	}


	//OnMouseClick:
	public void MouseClick()
	{
		// this object was clicked - do something
		Debug.Log ("Button clicked");


		//Clicking button will choose this talent, AND establish that a tier 1 talent has been selected.
		Player2.chose_Tier1Talent = true;
		Player2.tier1_Talent = 1;
		//player.check_TalentTier1 ();
	}   


	//OnMouseHover: called only once as entering frame.
	public void OnMouseEnter()
	{

		tooltip_Cleave_Talent.show_Tooltip();
		/*
		//Conditional, if talent CAN be chosen, but has not yet been chosen..
		if(Player2.player_Level >= 3)
		{


			//Original Plan: Only show tool tip if talent is selectable / otherwise keep it hidden.

			if(Player2.chose_Tier1Talent == false)
			{
				//SHOW CHILD OBJECT VISIBILITY FOR TOOLTIP
				//print ("HOVERING OVER");
				//print ("not chosen");
				tooltip_Cleave_Talent.show_Tooltip();
				
			}

			else if(Player2.chose_Tier1Talent == true)
			{
				//SHOW CHILD OBJECT VISIBILITY FOR TOOLTIP
				//print ("HOVERING OVER");
				//print ("CHOSEN");
				tooltip_Cleave_Talent.hide_Tooltip();
				
			}
		}
		*/
		
	}
	
	//OnMouseExit:
	public void OnMouseExit()
	{
		// if tooltip is visible, then hide it.
		
		tooltip_Cleave_Talent.hide_Tooltip();
		
		
		
		/*
		//Conditional, if talent CAN be chosen, but has not yet been chosen..
		if(Player2.player_Level >= 2)
		{
			if(Player2.chose_Tier1Talent == false)
			{
				//SHOW CHILD OBJECT VISIBILITY FOR TOOLTIP
				print ("Mouse Exit");
			}
		}
		*/
	}




}
