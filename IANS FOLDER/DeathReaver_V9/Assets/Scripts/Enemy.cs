using UnityEngine;
using System.Collections;

public class Enemy : Creature_Class
{
	//Define Variables:
	Player player;
	NavMeshAgent navAgent;
	public float chasingRange;
	bool block;	//Determine if enemy can attack or not based on attack speed.

	/*
	public string name = "First Enemy";
	public int health;
	public int damage;
	*/


	// Use this for initialization
	void Start () 
	{
		player = Player.player;
		navAgent = GetComponent<NavMeshAgent> ();
	}
	
	// Update is called once per frame
	void Update () 
	{
		Attack();
		FollowPlayer ();
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
		Player.opponent = transform;	//assigns the Player script's opponent variable to this enemy.
	}



	void FollowPlayer()
	{
		if (IsInRange (chasingRange)) 
		{
			navAgent.SetDestination (player.transform.position);
		} 

		else 
		{
			navAgent.SetDestination (transform.position);	//sets destination to itself.
		}
	}







	//New Method/Function. This Method will be used for the player's attacking.
	protected override void Attack()
	{

		if(Vector3.Distance(player.transform.position, transform.position) < range && !block)
		{
			player.GetHit (damage);
			block = true;
			Invoke ("UnBlock", attack_Speed); //call function after set amount of time.
		}
	}


	void UnBlock()
	{
		block = false;
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

}
