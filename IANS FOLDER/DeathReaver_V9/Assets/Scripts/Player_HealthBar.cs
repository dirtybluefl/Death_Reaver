using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Player_HealthBar : MonoBehaviour 
{

	//Define Variables:
	public static Player_HealthBar player_HealthBar;	//Reference to Player Health Bar.
	public Slider healthBarSliderPlayer;
	public float damage_Taken;
	public float new_MaxHealth;

	// Awake: Called Before start. 
	void Awake () 
	{
		player_HealthBar = this;		//Assign this object to the reference.
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
		//Debug.Log (healthBarSliderPlayer.maxValue + "max health");
		update_PlayerHealth ();


	}

	//Take Damage from Enemies and Update Health Bar:
	public void tookDamage(float damage_Taken)
	{
		//healthBarSliderPlayer.value = damage_Taken;		//changes health bar slider value for player, updates graphic.
	}

	//Update's the healthbar's max health value.
	public void update_MaxHealth(float new_MaxHealth)
	{	
		//healthBarSliderPlayer.maxValue = new_MaxHealth;		//changes health bar slider value for player, updates graphic.

	}


	//NEW HEALTH UPDATE:
	//Update's the healthbar's max health value.
	public void update_PlayerHealth()
	{	
		healthBarSliderPlayer.value = Player2.health;		//changes health bar slider value for player, updates graphic.
		healthBarSliderPlayer.maxValue = Player2.max_Health;		//changes health bar slider value for player, updates graphic.
		
	}



}
