using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class Staff_Specialization : MonoBehaviour 
{
	//Define Variables:
	CanvasGroup cg;
	public Tooltip_Staff tooltip_Staff;	//Provides direct access to the ToolTip_Mace script.
	public Player2 player;

	// Use this for initialization
	void Start () 
	{

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
				cg.interactable= true;
			}

			else if(Player2.chose_WeaponSpecialization == true)
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
		Player2.chose_WeaponSpecialization = true;
		Player2.weapon_Specialization = 3;

		//player.check_WeaponSpecialization();
	}   

	
	//OnMouseHover: called only once as entering frame.
	public void OnMouseEnter()
	{

		tooltip_Staff.show_Tooltip();

		/*
		//Conditional, if talent CAN be chosen, but has not yet been chosen..
		if(Player2.player_Level >= 2)
		{
			if(Player2.chose_Tier1Talent == false)
			{
				//SHOW CHILD OBJECT VISIBILITY FOR TOOLTIP
				//print ("HOVERING OVER");
				
				tooltip_Staff.show_Tooltip();
				
			}
		}
		*/
	}
	
	//OnMouseExit:
	public void OnMouseExit()
	{
		// if tooltip is visible, then hide it.
		
		tooltip_Staff.hide_Tooltip();
		
		
		
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
