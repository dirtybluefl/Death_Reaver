using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class tier3_Talent2 : MonoBehaviour 
{
	//Define Variables:
	CanvasGroup cg;
	public Tooltip_Warp_Talent tooltip_Warp_Talent;	//Provides direct access to the ToolTip_Mace script.


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
		if(Player_SoulBar.current_Souls >= Player2.level4_Unlock)
		{
			if(Player2.chose_Tier3Talent == false)
			{
				cg.interactable= true;
			}

			else if(Player2.chose_Tier3Talent == true)
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
		Player2.chose_Tier3Talent = true;
		Player2.tier3_Talent = 2;
	}   

	//OnMouseHover: called only once as entering frame.
	public void OnMouseEnter()
	{
		// Show Tooltip
		tooltip_Warp_Talent.show_Tooltip();
		
	}
	
	//OnMouseExit:
	public void OnMouseExit()
	{
		// Hide Tooltip
		tooltip_Warp_Talent.hide_Tooltip();
		
	}





}
