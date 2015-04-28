using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class Mace_Specialization : MonoBehaviour 
{
	//Define Variables:
	CanvasGroup cg;
	public Tooltip_Mace tooltip_Mace;	//Provides direct access to the ToolTip_Mace script.
	public Player2 player;

	// Use this for initialization
	void Start () 
	{
		//Only perform when game is in debug mode:
		if(CameraControl.debug_Mode == true)
		{
			//DEBUG:
			//Player_SoulBar.current_Souls = 76;
		}

		//print ("bloop");

		cg = this.GetComponent<CanvasGroup>();
		//clickButton.interactable = false;
	}
	
	// Update is called once per frame
	void Update () 
	{
		//Change Appearance based on State:
		if(Player_SoulBar.current_Souls >= Player2.level1_Unlock)
		{
			if(Player2.chose_WeaponSpecialization == false)
			{
				//cg.blocksRaycasts = true;
				cg.interactable= true;
			}

			else if(Player2.chose_WeaponSpecialization == true)
			{
				//cg.blocksRaycasts = false;
				cg.interactable= false;
			}
		}

		else
		{
			cg.interactable= false;
		}



	}


	//OnMouseClick:
	void MouseClick()
	{
		// this object was clicked - do something
		Debug.Log ("Button clicked");


		//Clicking button will choose this talent, AND establish that a tier 1 talent has been selected.
		Player2.chose_WeaponSpecialization = true;
		Player2.weapon_Specialization = 1;

		//player.check_WeaponSpecialization();
	}   



	/* PERSONAL NOTE: To get MOUSE OVER stuff to work for buttons, you have to add an event listener for "pointer over"
	 * and pick this function as the function to be called. */
	
	//OnMouseHover: called only once as entering frame.
	public void OnMouseEnter()
	{

		tooltip_Mace.show_Tooltip();

		/*
		//Conditional, if talent CAN be chosen, but has not yet been chosen..
		if(Player2.player_Level >= 2)
		{
			if(Player2.chose_Tier1Talent == false)
			{
				//SHOW CHILD OBJECT VISIBILITY FOR TOOLTIP
				//print ("HOVERING OVER");

				tooltip_Mace.show_Tooltip();

			}
		}
		*/

	}

	//OnMouseExit:
	public void OnMouseExit()
	{
		// if tooltip is visible, then hide it.

		tooltip_Mace.hide_Tooltip();



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
