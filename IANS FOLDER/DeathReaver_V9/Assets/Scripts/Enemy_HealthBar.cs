using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Enemy_HealthBar : MonoBehaviour 
{

	//Define Variables:
	public static Enemy_HealthBar enemy_HealthBar;	//Reference to Player Health Bar.
	public Slider healthBarSliderEnemy;
	public float damage_Taken;
	public float new_MaxHealth;
		//Gets component from slider.

	// Awake: Called Before start. 
	void Awake () 
	{
		enemy_HealthBar = this;		//Assign this object to the reference.
		hide_HealthBar ();
		//CanvasGroup cg = healthBarSliderEnemy.GetComponent<CanvasGroup>();
		//enemyHealthBarObj =  GameObject.Find("Enemy HealthBar");

		//Hides Health Bar:

		//cg.interactable= false;
		//cg.alpha = 0;
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



	}

	//Take Damage from Enemies and Update Health Bar:
	public void tookDamage(float damage_Taken)
	{
		healthBarSliderEnemy.value = damage_Taken;		//changes health bar slider value for player, updates graphic.
	}

	//Take Damage from Enemies and Update Health Bar:
	public void update_MaxHealth(float new_MaxHealth)
	{	
		healthBarSliderEnemy.maxValue = new_MaxHealth;		//changes health bar slider value for player, updates graphic.

	}

	//Hide Health Bar:
	public void hide_HealthBar()
	{	
		CanvasGroup cg = healthBarSliderEnemy.GetComponent<CanvasGroup>();
		cg.interactable= false;
		cg.alpha = 0;

	}

	//Hide Health Bar:
	public void hide_HealthBar2()
	{	
		Debug.Log ("Testttingg");
		
	}

	//Show Health Bar:
	public void show_HealthBar()
	{	
		CanvasGroup cg = healthBarSliderEnemy.GetComponent<CanvasGroup>();
		cg.interactable= true;
		cg.alpha = 1;
		
	}



}
