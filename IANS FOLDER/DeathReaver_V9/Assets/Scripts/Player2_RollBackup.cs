using UnityEngine;
using System.Collections;

public class Player2_RollBackup : MonoBehaviour
{
	//Define Variables:

	public static Player2_RollBackup player;			//Sets the Player variable to equal player character for reference.
	public AnimationClip attackAnimation;
	public new Animation animation;				//Access Animation Component.
	public static bool isAttacking;
	public static bool isRolling = false;
	public static bool roll_OnCooldown = false;
	Player_HealthBar player_HealthBar;
	public new string name;				//Player Chracter Name.
	public float health;				//Player Health Value.
	public float max_Health;				//Player Health Value.
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

	public float attack_Speed = 2.5f;	//per second.

	public static Transform opponent;	//Name after the "Enemy" Script. //opponent is the reference.	//Defined in enemy script.	
	//public static can be accesed without having script access.

	//ROLLING STUFF:
	public Vector3 currentPosition;
	public Vector3 rollPosition;
	public Vector3 directionOfTravel;
	public float roll_Speed = 100f;


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
		player_HealthBar.update_MaxHealth (max_Health);
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (CameraControl.game_Paused == false) 
		{
			Attack();
			roll_Movement();

		}

		//Debug.Log (this);
	}




	//FUNCTIONS:

	//FUNCTION Attack(): Handles the Player's Basic Attack Event.
	void Attack()
	{
		//Debug.Log ("Player is Attacking");

		if(isAttacking == false)
		{
			//Debug.Log ("Attacking is False");
			//if (Input.GetKeyUp (KeyCode.Space)) //replace with mouse click
			if (Input.GetMouseButtonDown(0))
			{

				//if Enemy is within attack range AND an opponent is selected.

				if(opponent != null && Vector3.Distance (opponent.position, transform.position) < range)
				{

					//Rotate towards enemy:
					transform.LookAt(opponent);



					Debug.Log ("Player Attacked!");
					isAttacking = true;
					opponent.GetComponent<Enemy2>().GetHit(damage);

					animation.CrossFade (attackAnimation.name);	//crossfade blends animations instead of playing immediaty.
					Invoke ("UnBlock", attack_Speed); //call function after set amount of time.
					//Enemy.GetHit(damage);
				}
			}
		}

		//When animation stops playing, attack cooldown is done.?
		if(!animation.IsPlaying (attackAnimation.name))
		{
			//isAttacking = false;
		}
	}

	//FUNCTION UnBlock(): Resets the Player's attack state to NOT ATTACKING after attack speed time.
	void UnBlock()
	{
		animation.Stop (attackAnimation.name);
		isAttacking = false;
	}


	// hit by external target.
	public void GetHit(int playerDamage)
	{
		//Playerdamage in this instance comes from the damage caused by incomming enemy attack.
		health = health - playerDamage;	//health minus player's damage amount.
		Debug.Log (health);	//show the enemy's new health.

		//Update Player Health Bar when Taking Damage:
		new_Health = (health / max_Health) * 100;
		new_Health = (Mathf.Round (new_Health));	//Round to integer.
		//Debug.Log (new_Health + "Percent");
		//healthBar.GetComponent<Player_HealthBar>().tookDamage(new_Health);

		//Might want to move this, only occurs when player is hit.
		//Update Player Health Bar to reflect damage.
		player_HealthBar.tookDamage (new_Health);
		player_HealthBar.update_MaxHealth (max_Health);	//Adjusts the max health value.
	}


	//Player Roll Function:
	public void roll_Movement()
	{

		
		if(Player2.roll_OnCooldown == false)
		{
			if (Input.GetKeyDown("space"))
			{
				//DEBUG:
				//ACTIVATE ROLLING:
				print ("spacebar pressed");
				print (transform.position);
				
				currentPosition = this.transform.position;
				rollPosition = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z + 20);

				print ("current position" + currentPosition);
				print ("roll position" + rollPosition);

				//navAgent.speed = 20;
				Player2.isRolling = true;
				//set roll cooldown to true.
				Player2.roll_OnCooldown = true;

				Invoke("disable_Rolling", 2);	//seconds
				Invoke("disable_RollCooldown", 4);	//seconds
			}
		}




		//Keep rolling:
		if(Player2.isRolling == true)
		{
			//PERFORM ROLL MOVEMENT:
			print ("rolling!");
			print (Player2.isRolling);
			Vector3 directionOfTravel = rollPosition - currentPosition;

			currentPosition = this.transform.position;

			this.transform.Translate(
				(directionOfTravel.x * roll_Speed * Time.deltaTime),
				(directionOfTravel.y * roll_Speed * Time.deltaTime),
				(directionOfTravel.z * roll_Speed * Time.deltaTime),
				Space.Self);

			//DEBUG:
			print ("Distance Left" + (Vector3.Distance(currentPosition, rollPosition)));
			print ("Current Position" + currentPosition);
			print ("Roll Position" + rollPosition);
			
			
			//IF TARGET REACHED, SET ROLLING TO FALSE.

			if(Vector3.Distance(currentPosition, rollPosition) <= 5) 
			{
				//DEBUG:
				print ("Distance Left" + (Vector3.Distance(currentPosition, rollPosition)));
				print ("Current Position" + currentPosition);
				print ("Roll Position" + rollPosition);
				



				print ("TARGET REACHED");
				//Player2.isRolling = false;
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

	//Player Roll Function (OLD VERSION):
	public void roll_Movement2()
	{
		if (Input.GetKeyDown("space"))
		{
			print ("spacebar pressed");
			//Warps forwards in direction player is facing.
			//transform.position += transform.forward * Time.deltaTime * 400;
			//transform.position += transform.forward * 1 * 20;

			//transform.Translate(Vector3.forward * 10, Space.Self);

		
			//transform.position = Vector3.Lerp(startMarker.position, endMarker.position, 5);



			//FAILURES:
			//player_Transform = GameObject.Find("Player").transform;
			//player_Transform.Translate (Vector3.forward * (2) * Time.deltaTime);
			//roll_Transform.position = new Vector3(player_Transform.transform.position.x + 200, player_Transform.transform.position.y + 0, player_Transform.transform.position.z + 0);
			//transform.position = Vector3.Lerp(player_Transform.position, roll_Transform.position, 2);
			//player_Transform.position = new Vector3(player_Transform.transform.position.x + 0, player_Transform.transform.position.y + 0, player_Transform.transform.position.z + 50);
		}


	}





}
