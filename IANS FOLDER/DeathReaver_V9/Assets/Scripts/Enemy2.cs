using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Enemy2 : MonoBehaviour
{
	//Define Variables:
	//CameraControl camera_Control;
	Player2 player;
	public GameObject enemyHealthBarTest;
	Enemy_HealthBar enemy_HealthBar;

	public GameObject player_SoulSlider;
	public int souls_Worth;
	Player_SoulBar player_SoulBar;

	Transform transformTest;

	NavMeshAgent navAgent;
	public float chasingRange;
	bool block;	//Determine if enemy can attack or not based on attack speed.

	public AnimationClip runAnimation;
	public AnimationClip idleAnimation;
	public AnimationClip attackAnimation;
	public AnimationClip deathAnimation;
	public new Animation animation;				//Access Animation Component.


	//public GameObject enemyHealthBar;


	public float health;				//Player Health Value.
	public float max_Health;				//Player Health Value.
	public float new_Health;				//Player Health Value.

	public GameObject Enemy1;
	public bool isAttacking;
	public bool isMoving;
	public bool isDead;
	public new string name;
	public int damage;
	public float range;
	public float attack_Speed = 2.5f;	//per second.



	// Use this for initialization
	void Awake () 
	{
		player = Player2.player;

		//Find By Name Approach to assigning reference.
		player_SoulSlider = GameObject.Find("Soul_Slider");



		transformTest = GetComponent<Transform> ();
		animation = GetComponent<Animation> ();
		//Transform EnemyTest = (Transform)Instantiate(Enemy1, transform.position, transform.rotation);
		//enemy_HealthBar = Enemy_HealthBar.enemy_HealthBar;
		//enemy_HealthBar.GetComponent<Enemy_HealthBar>();
		//enemy_HealthBar.hide_HealthBar2();
		//enemyHealthBar.GetComponent<Enemy_HealthBar>().hide_HealthBar();

		enemy_HealthBar = enemyHealthBarTest.GetComponentInChildren<Enemy_HealthBar>();
		player_SoulBar = player_SoulSlider.GetComponent<Player_SoulBar>();
		//player_SoulBar = Player_SoulBar.player_SoulBar;


		navAgent = GetComponent<NavMeshAgent> ();

	}
	
	
	// Use this for initialization
	void Start () 
	{
		//camera_Control = CameraControl.camera_Control;
		player = Player2.player;
		navAgent = GetComponent<NavMeshAgent> ();
		enemy_HealthBar.hide_HealthBar();
		//transform.name = transform.name.Replace("(clone)","Enemy1x").Trim();

	}
	
	// Update is called once per frame
	void Update () 
	{

		//Debug.Log (isDead);
		if(CameraControl.game_Paused == false)
		{

			if(isDead == false)
			{
				Attack ();
				FollowPlayer ();
				idle ();
				enemyDeath ();
			}
			
			else
			{
				destroyObject ();
			}
		}



	}
		/*
	// hit by target.
	public void GetHit(int playerDamage)
	{

		health = health - playerDamage;	//health minus player's damage amount.
		Debug.Log (health);	//show the enemy's new health.

	}
*/

	//mouse overing enemy for selection of target enemy.
	void OnMouseOver()
	{
		//Debug.Log ("Select ME " + gameObject.name);	//Prints out game object name.
		//
		//Debug.Log ("Mouse Over");

		//IF GAME IS NOT PAUSED:
		if(CameraControl.game_Paused == false)
		{
			//If still has health:
			if(health > 0)
			{
				Player2.opponent = transformTest;	//assigns the Player script's opponent variable to this enemy.
				Debug.Log (Player2.opponent);
				//enemy_HealthBar.show_HealthBar();	//Adjusts the max health value.
				enemy_HealthBar.show_HealthBar();
			}
			
			//new: tries to prevent player attacking from continuing even after target is dead.
			else if(health <= 0)
			{
				Player2.opponent = null;
			}
		}

	}

	void OnMouseExit()
	{
		enemy_HealthBar.hide_HealthBar();	//Adjusts the max health value.
		Player2.opponent = null;
		Player2.isAttacking = false;
	}



	void FollowPlayer()
	{
		if (IsInRange (chasingRange)&& !isAttacking) 
		{

			navAgent.SetDestination (player.transform.position);
			isMoving = true;
			animation.CrossFade (runAnimation.name);	//crossfade blends animations instead of playing immediaty.
			//Debug.Log ("running");
		} 

		else 
		{
			navAgent.SetDestination (transform.position);	//sets destination to itself.
			isMoving = false;
			//Debug.Log ("NOT running");
		}
	}







	//New Method/Function. This Method will be used for the player's attacking.
	void Attack()
	{

		if(Vector3.Distance(player.transform.position, transform.position) < range && !block)
		{
			//Attacking is true
			isAttacking = true;
			isMoving = false;
			animation.CrossFade (attackAnimation.name);


				


			Invoke ("doDamage", attack_Speed-2.0f); //call function after set amount of time.

			block = true;
			Invoke ("UnBlock", attack_Speed); //call function after set amount of time.
		}
	}


	void UnBlock()
	{
		block = false;
		isAttacking = false;
	}

	void doDamage()
	{
		player.GetHit (damage);	//Damage is given after attack animation is finished.
	}

	void idle()
	{
		if(!isMoving && !isAttacking)
		{
			animation.CrossFade (idleAnimation.name);	//crossfade blends animations instead of playing immediaty.
			//Debug.Log ("NOT running AND NOT Attacking");
		}
	}



	//Aggro Range. Check to see if player is close enough to start following.
	bool IsInRange(float range)
	{
		if (Vector3.Distance (player.transform.position, transform.position) < range) 
		{
			return true;
		} 

		else 
		{
			return false;
		}
	}

	// hit by external target.
	public void GetHit(int playerDamage)
	{

		//Player Reaver Ability Healing Attacks:
		//Healing Attacks if Reaver is active.
		if(player.ability_ReaverActive == true)
		{
			//print ("HEALING NOM NOM NOM");
			//print ("damage: " + player.damage);
			//print ("health before:   " + Player2.health);
			if((Player2.health += player.damage) <= Player2.max_Health)
			{
				Player2.health += player.damage;
			}
			else if((Player2.health += player.damage) > Player2.max_Health)
			{
				Player2.health = Player2.max_Health;
			}

			//print ("health after:   " + Player2.health);
		}




		health = health - playerDamage;	//health minus player's damage amount.
		Debug.Log (health);	//show the enemy's new health.
		
		//Update Player Health Bar when Taking Damage:
		new_Health = (health / max_Health) * 100;
		new_Health = (Mathf.Round (new_Health));	//Round to integer.
		//Debug.Log (new_Health + "Percent");
		//healthBar.GetComponent<Player_HealthBar>().tookDamage(new_Health);
		enemy_HealthBar.tookDamage (new_Health);
		enemy_HealthBar.update_MaxHealth (max_Health);	//Adjusts the max health value.
	}

	// Determine if Enemy health is less than or equal to 0, then performs death action.
	public void enemyDeath()
	{
		if(health <= 0)
		{
			//Debug.Log ("ENEMY DIED");	
			navAgent.Stop ();	//stops enemy from moving once he has died.

			enemy_HealthBar.hide_HealthBar();
			animation.CrossFade (deathAnimation.name);
	

			isDead = true;
			//player_SoulBar.gainSouls(souls_Worth);

			//print ("SOULS WORTH: " + this.souls_Worth);
			Player_SoulBar.current_Souls += this.souls_Worth;
			//print ("new souls count" + Player_SoulBar.current_Souls);
			//give player earned souls
			//destroy object.

		}

	}


	public void destroyObject()
	{
		Destroy(this.gameObject, 2.5f);		
	}

	//Function Called When hit by Stalwart Damage OverlapSphere.
	public void takeStalwartDamage(float damage)
	{
		print ("RAWRRRR");
		health = health - damage;	//health minus player's damage amount.
		Debug.Log (health);	//show the enemy's new health.
		
		//Update Player Health Bar when Taking Damage:
		new_Health = (health / max_Health) * 100;
		new_Health = (Mathf.Round (new_Health));	//Round to integer.
		//Debug.Log (new_Health + "Percent");
		//healthBar.GetComponent<Player_HealthBar>().tookDamage(new_Health);
		enemy_HealthBar.tookDamage (new_Health);
		enemy_HealthBar.update_MaxHealth (max_Health);	//Adjusts the max health value.
	}

	//Function Called When hit by Stalwart Damage OverlapSphere.
	public void takeWarpDamage(float damage)
	{
		print ("RAWRRRR WARP DAMAGE");
		health = health - damage;	//health minus player's damage amount.
		Debug.Log (health);	//show the enemy's new health.
		
		//Update Player Health Bar when Taking Damage:
		new_Health = (health / max_Health) * 100;
		new_Health = (Mathf.Round (new_Health));	//Round to integer.
		//Debug.Log (new_Health + "Percent");
		//healthBar.GetComponent<Player_HealthBar>().tookDamage(new_Health);
		enemy_HealthBar.tookDamage (new_Health);
		enemy_HealthBar.update_MaxHealth (max_Health);	//Adjusts the max health value.
	}


	//Detects when enemy is hit by the Player DRIVE shockwave talent:
	void OnTriggerEnter(Collider other) 
	{
		//Debug.Log ("OnTriggerEnter : other.tag = " + other.tag); // shows the tag of the trigger
		// if tag is door
		if (other.tag == "Shockwave")
		{
			print ("HIT BY SHOCKWAVE");
			health = health - Player2.drive_Shockwave_Damage;

			//Update Player Health Bar when Taking Damage:
			new_Health = (health / max_Health) * 100;
			new_Health = (Mathf.Round (new_Health));	//Round to integer.
			//Debug.Log (new_Health + "Percent");
			//healthBar.GetComponent<Player_HealthBar>().tookDamage(new_Health);
			enemy_HealthBar.tookDamage (new_Health);
			enemy_HealthBar.update_MaxHealth (max_Health);	//Adjusts the max health value.
			

		}
	}



















}
