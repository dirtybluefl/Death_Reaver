using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Player_SoulBar : MonoBehaviour 
{

	//Define Variables:
	public static Player_SoulBar player_SoulBar;	//Reference to Player Health Bar.

	public Slider Soul_Slider;
	public int souls_Gained;
	public static int current_Souls;
	public static int new_MaxSouls;

	// Awake: Called Before start. 
	void Awake () 
	{
		player_SoulBar = this;		//Assign this object to the reference.
	}


	// Use this for initialization
	void Start () 
	{
		//player_HealthBar = this;		//Assign this object to the reference.
		//Debug.Log (player_HealthBar + "tHIS");

	}
	
	// Update is called once per frame
	void Update () 
	{
		//Debug.Log (Soul_Slider.value + "CRRENT VALUE" );
		Soul_Slider.value = current_Souls;
		Soul_Slider.maxValue = new_MaxSouls;
		update_PlayerLevelMaxSouls ();

	}

	//Take Damage from Enemies and Update Health Bar:
	public void gainSouls(int souls_Gained)
	{
		//Gain no more souls once player has earned the absolute max value (currently 75)
		if(current_Souls < Player2.level4_Unlock)
		{
			//Debug.Log ("Gained Soul");
			current_Souls = (current_Souls + souls_Gained);
			Soul_Slider.value = (current_Souls);		//changes health bar slider value for player, updates graphic.
		}

	}


	public void update_MaxSouls(float new_MaxSouls)
	{	
		Soul_Slider.maxValue = new_MaxSouls;		

	}

	//Function will update the player's "level" based on number of souls they have. Will also update the Player's Max Souls value.
	public void update_PlayerLevelMaxSouls()
	{
		if(current_Souls < Player2.level1_Unlock)
		{
			//max souls = Player2.level1_Unlock
			new_MaxSouls = Player2.level1_Unlock;
			//player level = 0
			Player2.player_Level = 1;	//no talents yet for level 1

		}

		else if((Player2.level1_Unlock <= current_Souls) && (current_Souls < Player2.level2_Unlock))
		{
			//max souls = Player2.level1_Unlock
			new_MaxSouls = Player2.level2_Unlock;
			//player level = 1
			Player2.player_Level = 2;
		}

		else if((Player2.level2_Unlock <= current_Souls) && (current_Souls < Player2.level3_Unlock))
		{
			//max souls = Player2.level1_Unlock
			new_MaxSouls = Player2.level3_Unlock;
			//player level = 0
			Player2.player_Level = 3;
		}

		else if((Player2.level3_Unlock <= current_Souls) && (current_Souls < Player2.level4_Unlock))
		{
			//max souls = Player2.level1_Unlock
			new_MaxSouls = Player2.level4_Unlock;
			//player level = 0
			Player2.player_Level = 4;
		}

		else if(Player2.level4_Unlock <= current_Souls )
		{

			//max souls = Player2.level4_Unlock
			//player level = 4
			//Force soul count back to 75 if exceeds.
			//max souls = Player2.level1_Unlock
			new_MaxSouls = Player2.level4_Unlock;
			//player level = 0
			current_Souls = Player2.level4_Unlock;
			Player2.player_Level = 5;
		}




	}







}
