using UnityEngine;
using System.Collections;

public class Player2 : MonoBehaviour
{
	//Define Variables:

	public GameObject ShockWave;


	//DEFAULT VALUES (Can call back to whenever reseting back to normal)
	//private float default_Health = 300f;				//Player Health Value.	//WAS 1000.
	private float default_Max_Health = 300f;	
	private int default_damage = 15;							//Player Basic Attack Damage Amount.
	private float default_range = 5f;
	private float default_attack_Speed = 1.5f;	//per second.
	private float default_move_Speed = 8f;	//per second.
	private float default_damageReduction = 0.5f;
	private int default_health_Regen = 3;	//health per tick
	
	
	
	
	//For sake of Move Speed Changing:
	NavMeshAgent navAgent;
	
	
	//Other:
	public static Player2 player;			//Sets the Player variable to equal player character for reference.
	public AnimationClip attackAnimation;
	public new Animation animation;				//Access Animation Component.
	public static bool isAttacking;
	public static bool isBlocking = false;
	public static bool isRolling = false;
	public static bool roll_OnCooldown = false;
	Player_HealthBar player_HealthBar;
	public new string name;				//Player Chracter Name.
	public static float health = 300f;				//Player Health Value.
	public static float max_Health = 300f;				//Player Health Value.
	public float new_Health;				//Player Health Value.
	public int damage;				//Player Basic Attack Damage Amount.
	public float range;
	
	//Talent Booleans (Used to determine when a tier has a chosen talent):
	public static bool chose_WeaponSpecialization = false;
	public static bool chose_Tier1Talent = false;
	public static bool chose_Tier2Talent = false;
	public static bool chose_Tier3Talent = false;
	//Chosen Talents/Specializations:
	public static int weapon_Specialization = 0;
	public static int tier1_Talent = 0;
	public static int tier2_Talent = 0;
	public static int tier3_Talent = 0;
	//Setup Variables to hold each level up/unlock stage:
	public static int level1_Unlock = 4;
	public static int level2_Unlock = 20;
	public static int level3_Unlock = 50;
	public static int level4_Unlock = 75;
	
	public static Transform player_Transform;
	public Transform roll_Transform;
	
	public float attack_Speed = 1.5f;	//per second.
	
	public static Transform opponent;	//Name after the "Enemy" Script. //opponent is the reference.	//Defined in enemy script.
	public static GameObject opponent_Object;	
	
	//Determine Player Level / Soul level:
	public static int player_Level = 0;
	
	//Define enemy strings:
	public string Enemy_Type1 = "Enemy1x";
	public string Enemy_Type2 = "Ranged_Enemy";
	
	//public static can be accesed without having script access.
	
	//ROLLING STUFF:
	public Vector3 currentPosition;
	public Vector3 rollPosition;
	public Vector3 directionOfTravel;
	public float roll_Speed = 0.00001f;
	
	//BLocking Stuff:
	public static float damageReduction = 0.5f;
	
	//Health Regeneration:
	public int health_Regen = 3;	//health per tick
	public int health_RegenRate = 2; //per second.
	
	//Saved Stats:
	public static float save_Health = 300f;				//Player Health Value.
	public static float save_Max_Health = 300f;	
	public static int save_Current_Souls;
	public static bool save_Chose_WeaponSpecialization = false;
	public static bool save_Chose_Tier1Talent = false;
	public static bool save_Chose_Tier2Talent = false;
	public static bool save_Chose_Tier3Talent = false;
	public static int save_Weapon_Specialization = 0;
	public static int save_Tier1_Talent = 0;
	public static int save_Tier2_Talent = 0;
	public static int save_Tier3_Talent = 0;
	
	
	
	//GUI DETECTION (did not work):
	//public static bool over_GUI = false;
	
	//TALENTS STUFF:
	int ability1_Cooldown = 0;	//The default value for ability 1 cooldown. Tracks the cooldown for activatable ability #1.
	int ability2_Cooldown = 0;	//The default value for ability 1 cooldown. Tracks the cooldown for activatable ability #2.
	//Booleans for abilities:
	bool ability1_OnCooldown = false;
	bool ability2_OnCooldown = false;
	public static bool ability_ChargeActive = false;
	public bool ability_DriveActive = false;
	public bool ability_StalwartActive = false;
	public bool ability_UnbreakableActive = false;
	public static bool ability_WarpActive = false;
	public bool ability_ReaverActive = false;
	int ability_ChargeTime = 2;		//Charge ability should last for no more than 2 seconds.
	int ability_StalwartTime = 4;		//ability lasts for 4 seconds.
	int ability_UnbreakableTime = 15;   //Unbreakable lasts for 15 seconds.
	int ability_WarpTime = 4;   		//Warp activation lasts for 4 seconds before charge is lost.
	int ability_ReaverTime = 15;		//Ability lasts for 15 seconds.
	int damage_BeforeReaver;
	
	float stalwart_Range = 8;  //range of stalwart Talent.
	float stalwart_Rate = 0.5f;  //range of stalwart Talent.
	float stalwart_Damage = 15f;  //damage of stalwart Talent.

	//Warp Talent Info:
	int warp_Counters = 3;
	int max_Warp_Counters = 3;

	//Drive Shockwave:
	public static int drive_Shockwave_Damage = 150;

	public bool playerHasArmor;
	Vector3 chargePosition;
	
	// Awake: Called Before start. 
	void Awake () 
	{
		player_Transform = GameObject.Find("Player").transform;
		
		player = this;
		player_HealthBar = Player_HealthBar.player_HealthBar;	//Assign reference to player health bar.
		//Debug.Log (player_HealthBar + "This");
		animation = GetComponent<Animation> ();
		isAttacking = false;
	}
	
	
	// Use this for initialization
	void Start () 
	{
		//Initialize stuff:
		//health = 100f;
		StartCoroutine(health_Regenerate());
		
		navAgent = GetComponent<NavMeshAgent> ();	//Retrieves info from NavMeshAgent navAgent.
		
		
		//TEST:
		//navAgent.speed = 50;
		
		//player_HealthBar.update_MaxHealth (default_Max_Health);
	}
	
	// Update is called once per frame
	void Update () 
	{
		//print ("Player damage" + damage); //mace specialization is not increasing damage currently.

		if (CameraControl.game_Paused == false) 
		{
			Attack();
			roll_Movement();
			
			
			check_TalentTier2();
			check_TalentTier3();
			perform_StalwartTalent();

			if(ability_ChargeActive == true)
			{
				charge_Movement();
			}


			//Call health regen script once per regen rate.
			//Invoke("health_Regenerate", health_RegenRate);
			//print (navAgent.speed);
		}
		//print (ability_ReaverActive);
		//Debug.Log (this);
	}
	
	
	
	
	//FUNCTIONS:
	
	//FUNCTION Attack(): Handles the Player's Basic Attack Event.
	void Attack()
	{
		//Debug.Log ("Player is Attacking");
		
		
		if (isBlocking == false) 
		{
			//ADD EXTRA CONDITIONAL TO ELIMINATE ATTACKING WHILE ROLLING, OTHERWISE, Player charges forward and plows through enemies, kinda cool though.
			if(isRolling == false)
			{
				
				
				//Debug.Log ("Attacking is False");
				//if (Input.GetKeyUp (KeyCode.Space)) //replace with mouse click
				if (Input.GetMouseButton(0))
				{
					
					//if Enemy is within attack range AND an opponent is selected.
					if(isAttacking == false)
					{
						if(opponent != null && Vector3.Distance (opponent.position, transform.position) < range)
						{
							
							//Rotate towards enemy:
							transform.LookAt(opponent);
							
							
							
							//Debug.Log ("Player Attacked!");
							isAttacking = true;
							
							//DEBUG TO MAKE SURE TRANSFORM NAME IS COMPARED CORRECTLY TO DETERMINE ENEMY BEING ATTACKED.
							//print ("to string:     " + opponent.name);
							//print ("Enemy Type 1:     " + Enemy_Type1);
							//print (string.Compare(opponent.ToString(), "Enemy1x"));
							//print ("Enemy Type 1:     " + Enemy_Type1);
							
							
							
							
							//Handle different types of enemies:
							if(string.Compare(opponent.name, Enemy_Type1) == 0)
							{
								//print ("yay!!");
								opponent.GetComponent<Enemy2>().GetHit(damage);
							}
							
							//Handle different types of enemies:
							if(string.Compare(opponent.name, Enemy_Type2) == 0)
							{
								//print ("yay!!");
								opponent.GetComponent<Ranged_Enemy>().GetHit(damage);
							}
							
							
							animation.CrossFade (attackAnimation.name);	//crossfade blends animations instead of playing immediaty.
							Invoke ("UnBlock", attack_Speed); //call function after set amount of time.
							//Enemy.GetHit(damage);
						}
					}
				}
				
			}
			
			//When animation stops playing, attack cooldown is done.?
			if(!animation.IsPlaying (attackAnimation.name))
			{
				//isAttacking = false;
			}
		}
		
	}
	
	//FUNCTION UnBlock(): Resets the Player's attack state to NOT ATTACKING after attack speed time.
	void UnBlock()
	{
		isAttacking = false;
		animation.Stop (attackAnimation.name);
		
	}
	
	
	// hit by external target.
	public void GetHit(int playerDamage)
	{
		//if unbreakable talent is active then do nothing, else ... blocking conditional
		

		//Take no damage.
		if(ability_UnbreakableActive == true)
		{
			print ("haha not taking damage");
			//do nothing.
			return;
		}

		//Calculate damage as normal.
		else if(ability_UnbreakableActive == false)
		{
			if(Player2.isBlocking == true)
			{
				//Playerdamage in this instance comes from the damage caused by incomming enemy attack.
				Player2.health = (Player2.health - (playerDamage - (playerDamage * damageReduction)));	//health minus player's damage amount.
				Debug.Log (health);	//show the enemy's new health.
			}
			
			else if(Player2.isBlocking == false)
			{
				//Playerdamage in this instance comes from the damage caused by incomming enemy attack.
				Player2.health = Player2.health - playerDamage;	//health minus player's damage amount.
				Debug.Log (Player2.health);	//show the enemy's new health.
			}
		}




		

		
		
		
		//Update Player Health Bar when Taking Damage:
		new_Health = (health / max_Health) * 100;
		new_Health = (Mathf.Round (new_Health));	//Round to integer.
		//Debug.Log (new_Health + "Percent");
		//healthBar.GetComponent<Player_HealthBar>().tookDamage(new_Health);
		
		//Might want to move this, only occurs when player is hit.
		//Update Player Health Bar to reflect damage.
		//player_HealthBar.tookDamage (new_Health);
		//player_HealthBar.update_MaxHealth (max_Health);	//Adjusts the max health value.
	}
	
	
	//Player Roll Function:
	public void roll_Movement()
	{
		
		if(ability_ChargeActive == false)
		{
			if(Player2.roll_OnCooldown == false)
			{
				if (isBlocking == false)
				{
					if (Input.GetKeyDown("space"))
					{
						//DEBUG:
						//ACTIVATE ROLLING:
						//print ("spacebar pressed");
						//print (transform.position);
						
						currentPosition = this.transform.position;
						rollPosition = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z + 20);
						
						//print ("current position" + currentPosition);
						//print ("roll position" + rollPosition);
						
						//navAgent.speed = 20;
						Player2.isRolling = true;
						//set roll cooldown to true.
						Player2.roll_OnCooldown = true;
						
						Invoke("disable_Rolling", 2);	//seconds
						Invoke("disable_RollCooldown", 4);	//seconds
					}
				}
			}
		}

		
		
		
		
		//Keep rolling:
		if(Player2.isRolling == true)
		{
			//PERFORM ROLL MOVEMENT:
			//print ("rolling!");
			//print (Player2.isRolling);
			Vector3 directionOfTravel = rollPosition - currentPosition;
			
			currentPosition = this.transform.position;
			
			this.transform.Translate(
				(0),
				(0),
				(directionOfTravel.z * roll_Speed * Time.deltaTime),
				Space.Self);
			
			//DEBUG:
			//print ("Distance Left" + (Vector3.Distance(currentPosition, rollPosition)));
			//print ("Current Position" + currentPosition);
			//print ("Roll Position" + rollPosition);
			
			
			//IF TARGET REACHED, SET ROLLING TO FALSE.
			
			if(Vector3.Distance(currentPosition, rollPosition) <= 5) 
			{
				//DEBUG:
				//print ("Distance Left" + (Vector3.Distance(currentPosition, rollPosition)));
				//print ("Current Position" + currentPosition);
				//print ("Roll Position" + rollPosition);
				
				
				
				
				//print ("TARGET REACHED");
				Player2.isRolling = false;
				//Invoke("disable_RollCooldown", 4);	//seconds
			}
			
			
			
			//INVOKE, set roll cooldown to off after set time.
			
		}
	}
	
	public void disable_RollCooldown()
	{
		Player2.roll_OnCooldown = false;
	}
	
	public void disable_Rolling()
	{
		Player2.isRolling = false;
	}
	
	//Player Health Regeneration:
	//Uses a CoRoutine.
	IEnumerator health_Regenerate()
	{
		while(true)
		{
			if (CameraControl.game_Paused == false) 
			{
				//print ("HEALING!");
				if((Player2.health + health_Regen) > Player2.max_Health)
				{
					Player2.health = Player2.max_Health;
				}
				
				else if((Player2.health + health_Regen) <= Player2.max_Health)
				{
					Player2.health += health_Regen;
				}
			}
			
			
			yield return new WaitForSeconds(health_RegenRate);
		}
		
	}
	
	//Weapon Specialization Talent Checker Function:
	//Enables/Disables The Player Stat Bonuses according to talent state and talent choice:
	public void check_WeaponSpecialization()
	{
		//WILL BE CALLED FROM TALENT MENU TALENT BUTTONS, AND THE TALENT MENU RESET BUTTON TO RESET.
		print ("updating weapon spec stuff");
		
		//Enable/Toggle ON:
		//___________________________________________
		
		//Mace Weapon Specialization:
		if(weapon_Specialization == 1)
		{
			//Switch Player Weapon Model to Warped Mace.
			
			print ("Adding Mace Bonus");
			print (damage );
			//Basic melee damage + 40%.

			damage += (int)(damage * 0.4);
			//print((damage * 0.2));
			print (damage );
			//Health increased by 200 points.
			health += 200;
			max_Health += 200;
			
			
		}
		
		//Sword Weapon Specialization:
		else if(weapon_Specialization == 2)
		{
			//Switch Player Weapon Model to Warped Sword.
			print ("Adding Sword Bonus");
			//basic Melee Attack Range increased to 2.5 meters, up from 2 meters.
			range += (range * 0.25f); //25% increase
			
			//Attack speed increased to 1 attack ever 1.2 seconds, up from 1.5 seconds.
			attack_Speed = 1.2f;
			
			
			//Basic melee damage + 5%. ???? Update Improvement Suggestion
			//damage += (int)(damage * 0.05);
			damage += 2;
			
			
			
		}
		
		//Staff Weapon Specialization:
		else if(weapon_Specialization == 3)
		{
			//Switch Player Weapon Model to Warped Staff.
			print ("Adding Staff Bonus");
			//Blocking Damage Reduction Increased to 60%, Up from 50%
			damageReduction = 0.6f;
			
			
			//Movement Speed Increased to 2.8 Meters per Second, Up from 2.0 Meters, = 12
			navAgent.speed += (navAgent.speed * 0.4f);
			
			
			//Basic Melee Attack range increased to 3.5 Meters, up from 2.0 Meters.
			range += (range * 0.75f); //75% increase
			
			
		}
		
		//Disable/toggle back off if disabled:
		//___________________________________________
		else 
		{
			//Switch Player Weapon Model to ....Default Weapon??? .
			print ("returning to defaults");
			//Return to Defaults:
			max_Health = default_Max_Health;
			damage = default_damage;
			attack_Speed = default_attack_Speed;
			range = default_range;
			damageReduction = default_damageReduction;
			navAgent.speed = default_move_Speed;
			
			if(health > max_Health)
			{
				health = max_Health;
			}
		}
	}
	//End of check weapon specialization function.
	
	
	
	//Function Checks for the Passive Talents from Tier 1 Selection:
	//Enables/Disables The Player Stat Bonuses according to talent state and talent choice:
	public void check_TalentTier1()
	{
		//WILL BE CALLED FROM TALENT MENU TALENT BUTTONS, AND THE TALENT MENU RESET BUTTON TO RESET.
		
		
		//Enable/Toggle ON:
		//___________________________________________
		
		//Toughness Talent Choice:
		if(tier1_Talent == 1)
		{
			//+3 Health regeneration rate.
			health_Regen += 3;
			print ("TOUGHNESS TALENT ACTIVATED");
			
			
		}
		
		//Determination Talent Choice:
		else if(tier1_Talent == 2)
		{
			//Increases Player's Basic Attack Speed by 0.3 Seconds.
			print (attack_Speed);
			attack_Speed -= 0.3f;	// subtract since makes it faster.
			print ("DETERMINATION TALENT ACTIVATED");
			print (attack_Speed);
		}
		
		//Might Talent Choice:
		else if(tier1_Talent == 3)
		{
			//Increases Player's Basic Melee Attack Damage by 30%.
			print (damage);
			damage += (int)(damage * 0.3);
			print ("MIGHT TALENT ACTIVATED");
			print (damage);
		}
		
		
		
		//Disable/toggle back off if disabled:
		//___________________________________________
		else 
		{
			print ("Tier 1 Reset");
			//Return to Defaults:
			health_Regen = default_health_Regen;
			attack_Speed = default_attack_Speed;	// subtract since makes it faster.
			damage = default_damage;
			
			
			
		}
		
		
	}
	//End of check Talent Tier 1 function.
	
	
	
	
	//Function Checks for Tier 2 Talents:
	public void check_TalentTier2()
	{
		//Charge Talent:
		//If talent tier 2 choice = 1
		if (tier2_Talent == 1) 
		{
			ability1_Cooldown = 15; //15 seconds cool down.
			activate_ChargeTalent();
			
			
			
		}

		//Drive Talent:
		//Else If talent tier 2 choice = 2
		else if (tier2_Talent == 2) 
		{
			
			ability1_Cooldown = 20; //20 seconds cool down.
			activate_DriveTalent();
			
			
			
		}
		
		//Else If talent tier 2 choice = 3
		//Stalwart Talent:
		else if (tier2_Talent ==3) 
		{
			
			ability1_Cooldown = 20; //20 seconds cool down.
			activate_StalwartTalent();
			
			
		}
		
		//else:
		//Reset back to normal.
		else
		{
			ability1_Cooldown = 0;
		}
		
		
	}
	

	//Function for activating the Drive Talent: _______________________________________________
	public void activate_ChargeTalent()
	{
		//Enables Drive Talent if conditionals are met and is not on cooldown.
		//starts cooldown once ability is activated
		
		//If Stalwart is the chosen talent.
		if(ability1_OnCooldown == false)
		{
			if(tier2_Talent == 1)
			{
				//If the "1" Number Key is Clicked...
				if (Input.GetKeyDown(KeyCode.Alpha1))
				{
					print ("1 key pressed for Charge Talent");
					print ("CHARGE ACTIVATED");
					
					//SPAWN SHOCKWAVE HERE:
					
					print("CHARGING!!");
					ability_ChargeActive = true;
					//Roll simulation clone code:
					//charge_Movement();








					//SPAWN OBJECT FOR COLLISION WITH ENEMIES, spawn as child object in front of player.
					//Reference for ranged combat enemies.
					//Creates a new vector3 using the Current Object's transforms broken down into X Y Z components.
				//	Vector3 spawnPos = new Vector3 (this.transform.position.x, this.transform.position.y + 1, this.transform.position.z);
					
				//	Instantiate (ShockWave, spawnPos, this.transform.rotation);

					//spawn as child of current object.
					//(Instantiate (m_Prefab, position, rotation) as GameObject).transform.parent = transform;
					
					
					
					ability1_OnCooldown = true;
					
					Invoke("disable_ChargeTalent", ability_ChargeTime);
					Invoke("cooldown_ChargeTalent", ability1_Cooldown);
					
					
				}
			}
			
		}
		
		
	}//End of Charge Function. ___________________________________________
	
	
	
	//Function Refreashes Talent Ability Once Cooldown is finished.
	public void cooldown_ChargeTalent()
	{
		print ("Charge Cooldown DONE, can use again");
		ability1_OnCooldown = false;
	}


	//Function Disables  Stalwart Talent When Ability is Finished (after 20 seconds):
	public void disable_ChargeTalent()
	{
		print ("Charge Disabled");
		ability_ChargeActive = false;

	}

















	//Function for activating the Drive Talent: _______________________________________________
	public void activate_DriveTalent()
	{
		//Enables Drive Talent if conditionals are met and is not on cooldown.
		//starts cooldown once ability is activated
		
		//If Stalwart is the chosen talent.
		if(ability1_OnCooldown == false)
		{
			if(tier2_Talent == 2)
			{
				//If the "1" Number Key is Clicked...
				if (Input.GetKeyDown(KeyCode.Alpha1))
				{
					print ("1 key pressed for Drive Talent");
					print ("DRIVE ACTIVATED");

					//SPAWN SHOCKWAVE HERE:

					print("LAUNCHED!");

					//Reference for ranged combat enemies.
					//Creates a new vector3 using the Current Object's transforms broken down into X Y Z components.
					Vector3 spawnPos = new Vector3 (this.transform.position.x, this.transform.position.y + 1, this.transform.position.z);

					Instantiate (ShockWave, spawnPos, this.transform.rotation);




					ability1_OnCooldown = true;
					

					Invoke("cooldown_DriveTalent", ability1_Cooldown);
					

				}
			}
			
		}
		
		
	}//End of Stalwart Function. ___________________________________________
	

	
	//Function Refreashes Talent Ability Once Cooldown is finished.
	public void cooldown_DriveTalent()
	{
		print ("Drive Cooldown DONE, can use again");
		ability1_OnCooldown = false;
	}








	//Function for activating the Stalwart Talent: _______________________________________________
	public void activate_StalwartTalent()
	{
		//Enables Stalwart Talent if conditionals are met and is not on cooldown.
		//starts cooldown once ability is activated
		
		//If Stalwart is the chosen talent.
		if(ability1_OnCooldown == false)
		{
			if(tier2_Talent == 3)
			{
				//If the "1" Number Key is Clicked...
				if (Input.GetKeyDown(KeyCode.Alpha1))
				{
					print ("1 key pressed for Stalwart Talent");
					print ("STALWART ACTIVATED");
					ability_StalwartActive = true;
					ability1_OnCooldown = true;
					
					Invoke("disable_StalwartTalent", ability_StalwartTime);
					Invoke("cooldown_StalwartTalent", ability1_Cooldown);
					
					//IENUMBERATOR DEAL DAMAGE TO ENEMIES EVERY SO OFTEN. START NUMERATOR
				}
			}
			
		}
		
		
	}//End of Stalwart Function. ___________________________________________
	
	//Function Disables  Stalwart Talent When Ability is Finished (after 20 seconds):
	public void disable_StalwartTalent()
	{
		print ("Stalwart Disabled");
		ability_StalwartActive = false;
		//IENUMBERATOR DEAL DAMAGE TO ENEMIES EVERY SO OFTEN. STOP NUMERATOR, PLACE ON ENEMY INSTEAD?
	}
	
	
	//Function Refreashes Talent Ability Once Cooldown is finished.
	public void cooldown_StalwartTalent()
	{
		print ("Stalwart Cooldown DONE, can use again");
		ability1_OnCooldown = false;
	}
	
	//Function Disables  Stalwart Talent When Ability is Finished (after 20 seconds):
	public void perform_StalwartTalent()
	{
		
		if (player.ability_StalwartActive == true) 
		{
			StartCoroutine(stalwart_Cycle());
		}
		
		else if (player.ability_StalwartActive == false) 
		{
			StopCoroutine(stalwart_Cycle());
		}
		
		
	}
	
	
	//Function causes Damage to Enemy When Player is Using Stalwart Ability every so often when in range.
	IEnumerator stalwart_Cycle()
	{
		
		StalwartDamage(transform.position, stalwart_Range);  
		
		print ("BOOM BOOM BOOM");
		yield return new WaitForSeconds(stalwart_Rate);
	}
	
	
	void StalwartDamage(Vector3 center, float radius) 
	{
		print ("kaboom");
		Collider[] hitColliders = Physics.OverlapSphere(center, radius);
		int i = 0;
		while (i < hitColliders.Length) 
		{
			hitColliders [i].SendMessage("takeStalwartDamage",stalwart_Damage,SendMessageOptions.DontRequireReceiver);
			//SendMessage("StalwartDamage", stalwart_Damage, SendMessageOptions.DontRequireReceiver);
			i++;
		}
	}//END STALWART DAMAGE FUNCTION.
	
	
	
	//Function Checks for Tier 3 Talents:___________________________________________________
	public void check_TalentTier3()
	{
		//If talent tier 3 choice = 1
		//Unbreakable Talent.
		if (tier3_Talent == 1) 
		{
			ability2_Cooldown = 60;  //60 seconds cool down for Unbreakable, change later to reduce?.
			activate_UnbreakableTalent();
			
			
			
		}
		
		//Else If talent tier 3 choice = 2
		//Warp Talent.
		else if (tier3_Talent == 2) 
		{
			//print ("warp talent chosen?");
			ability2_Cooldown = 45;  //45 seconds cool down for Warp Talent to recover 1/3 warp counters.
			activate_WarpTalent();
			
			
			
		}
		
		//Else If talent tier 3 choice = 3
		//Reaver Talent.
		else if (tier3_Talent ==3) 
		{
			
			ability2_Cooldown = 60;  //60 seconds cool down.
			activate_ReaverTalent();
			
			
		}
		
		//else:
		//Reset back to normal.
		else
		{
			ability2_Cooldown = 0;
		}
		
		
	}
	

	//Function Checks for Tier 2 Talents:
	public void activate_UnbreakableTalent()
	{
		//Enables Unbreakable Talent if conditionals are met and is not on cooldown.
		//starts cooldown once ability is activated
		
		//If Unbreakable is the chosen talent.
		if(ability2_OnCooldown == false)
		{
			if(tier3_Talent == 1)
			{
				//If the "1" Number Key is Clicked...
				if (Input.GetKeyDown(KeyCode.Alpha2))
				{
					print ("2 key pressed for Unbreakable Talent");
					print ("Unbreakable ACTIVATED");
					ability_UnbreakableActive = true;
					ability2_OnCooldown = true;
					
					//Damage GetHIT function will be changed to prevent damage to be caused to the player.
					
					
					
					
					Invoke("disable_UnbreakableTalent", ability_UnbreakableTime);	//how long it lasts.
					Invoke("cooldown_UnbreakableTalent", ability2_Cooldown);
					
					//IENUMBERATOR DEAL DAMAGE TO ENEMIES EVERY SO OFTEN. START NUMERATOR
				}
			}
			
		}
		
		
	}//End of Stalwart Function.
	
	//Function Disables  Stalwart Talent When Ability is Finished (after 20 seconds):
	public void disable_UnbreakableTalent()
	{
		print ("Unbreakable Disabled");
		//damage = damage_BeforeReaver;
		ability_UnbreakableActive = false;
		//IENUMBERATOR DEAL DAMAGE TO ENEMIES EVERY SO OFTEN. STOP NUMERATOR, PLACE ON ENEMY INSTEAD?
	}
	
	
	//Function Refreashes Talent Ability Once Cooldown is finished.
	public void cooldown_UnbreakableTalent()
	{
		print ("Unbreakable Cooldown DONE, can use again");
		ability2_OnCooldown = false;
	}


	//Warp Talent


	//Function for activating the Warp Talent: _______________________________________________
	public void activate_WarpTalent()
	{
		//Enables Warp Talent if conditionals are met and is not on cooldown.
		//starts cooldown once ability is activated

		//If Stalwart is the chosen talent.
		if(ability2_OnCooldown == false)
		{
			if(tier3_Talent == 2)
			{
				if(ability_WarpActive == false)
				{
					//If the "2" Number Key is Clicked...
					if (Input.GetKeyDown(KeyCode.Alpha2))
					{
						print ("2 key pressed for Warp Talent");
						print ("WARP ACTIVATED");
						ability_WarpActive = true;
						//ability2_OnCooldown = true;
						warp_Counters -= 1;
						
						
						if(warp_Counters > 0)
						{
							ability2_OnCooldown = false;
						}
						
						else if(warp_Counters <= 0)
						{
							ability2_OnCooldown = true;
						}
						
						
						Invoke("disable_WarpTalent", ability_WarpTime);	//how long it lasts.
						//warp talent will be disabled when used.
						Invoke("cooldown_WarpTalent", ability2_Cooldown);
					}
				}

			}
			
		}
		
		
	}//End of Warp Function. ___________________________________________


	//Function Refreashes Talent Ability Once Cooldown is finished.
	public void cooldown_WarpTalent()
	{

		if(warp_Counters < max_Warp_Counters)
		{
			print ("Warp Cooldown DONE, can use again");
			warp_Counters += 1;

			if(warp_Counters > 0)
			{
				ability2_OnCooldown = false;
			}
			
			else if(warp_Counters <= 0)
			{
				ability2_OnCooldown = true;
			}
			//Reference Click to Move for the rest.
		}
	}

	//Function Disables  Warp Talent When Charge time is over (after 3 seconds):
	public void disable_WarpTalent()
	{
		print ("Warp Disabled");

		ability_WarpActive = false;
		//IENUMBERATOR DEAL DAMAGE TO ENEMIES EVERY SO OFTEN. STOP NUMERATOR, PLACE ON ENEMY INSTEAD?
	}



	//End Warp Talent

	//Function Checks for Tier 2 Talents:
	public void activate_ReaverTalent()
	{
		//Enables Stalwart Talent if conditionals are met and is not on cooldown.
		//starts cooldown once ability is activated
		
		//If Stalwart is the chosen talent.
		if(ability2_OnCooldown == false)
		{
			if(tier3_Talent == 3)
			{
				//If the "1" Number Key is Clicked...
				if (Input.GetKeyDown(KeyCode.Alpha2))
				{
					print ("2 key pressed for Reaver Talent");
					print ("Reaver ACTIVATED");
					ability_ReaverActive = true;
					ability2_OnCooldown = true;
					
					//Change stats here:
					damage_BeforeReaver = damage;
					damage += (int)(damage * 0.3);
					
					
					
					
					Invoke("disable_ReaverTalent", ability_ReaverTime);	//how long it lasts.
					Invoke("cooldown_ReaverTalent", ability2_Cooldown);
					
					//IENUMBERATOR DEAL DAMAGE TO ENEMIES EVERY SO OFTEN. START NUMERATOR
				}
			}
			
		}
		
		
	}//End of Stalwart Function.
	
	//Function Disables  Stalwart Talent When Ability is Finished (after 20 seconds):
	public void disable_ReaverTalent()
	{
		print ("Reaver Disabled");
		damage = damage_BeforeReaver;
		ability_ReaverActive = false;
		//IENUMBERATOR DEAL DAMAGE TO ENEMIES EVERY SO OFTEN. STOP NUMERATOR, PLACE ON ENEMY INSTEAD?
	}
	
	
	//Function Refreashes Talent Ability Once Cooldown is finished.
	public void cooldown_ReaverTalent()
	{
		print ("Reaver Cooldown DONE, can use again");
		ability2_OnCooldown = false;
	}
	
	
	
	public void charge_Movement()
	{
	
		print ("charge movement");	
			currentPosition = this.transform.position;
			chargePosition = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z + 20);
					
			//Player2.isRolling = true;
			//Player2.roll_OnCooldown = true;
			
			//Invoke("disable_Rolling", 2);	//seconds
			//Invoke("disable_RollCooldown", 4);	//seconds

		
		
		
		//Keep rolling:
		if(ability_ChargeActive == true)
		{
			//PERFORM ROLL MOVEMENT:
			//print ("rolling!");
			//print (Player2.isRolling);
			Vector3 directionOfTravel = chargePosition - currentPosition;
			
			currentPosition = this.transform.position;
			
			this.transform.Translate(
				(0),
				(0),
				(directionOfTravel.z * roll_Speed * Time.deltaTime),
				Space.Self);
			
			//DEBUG:
			//print ("Distance Left" + (Vector3.Distance(currentPosition, rollPosition)));
			//print ("Current Position" + currentPosition);
			//print ("Roll Position" + rollPosition);
			
			
			//IF TARGET REACHED, SET ROLLING TO FALSE.
			
			if(Vector3.Distance(currentPosition, chargePosition) <= 5) 
			{
				print ("reached destination");
				//DEBUG:
				//print ("Distance Left" + (Vector3.Distance(currentPosition, rollPosition)));
				//print ("Current Position" + currentPosition);
				//print ("Roll Position" + rollPosition);
				
				
				
				
				//print ("TARGET REACHED");
				ability_ChargeActive = false;
				//Invoke("disable_RollCooldown", 4);	//seconds
			}
			
			
			
			//INVOKE, set roll cooldown to off after set time.
			
		}




	}
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
}
