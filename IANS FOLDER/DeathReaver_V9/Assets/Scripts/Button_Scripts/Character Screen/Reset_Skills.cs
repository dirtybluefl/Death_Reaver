using UnityEngine;
using System.Collections;

public class Reset_Skills : MonoBehaviour 
{
	//Define Variables:
	public Player2 player;


	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}

	//RESETS all of the chosen talents/skills when clicked.
	//OnMouseClick:
	public void MouseClick()
	{
		// this object was clicked - do something
		Debug.Log ("Button clicked");
		//Reset booleans for determining if a talent/skill has been chosen for each level.
		Player2.chose_WeaponSpecialization = false;
		Player2.chose_Tier1Talent = false;
		Player2.chose_Tier2Talent = false;
		Player2.chose_Tier3Talent = false;
		//Reset chosen talents/skills to 0
		Player2.weapon_Specialization = 0;
		Player2.tier1_Talent = 0;
		Player2.tier2_Talent = 0;
		Player2.tier3_Talent = 0;

		player.check_WeaponSpecialization();
		player.check_TalentTier1 ();
	}   



}
