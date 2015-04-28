using UnityEngine;
using System.Collections;

public class Player : Creature_Class 
{
	//Define Variables:

	public static Player player;
	public AnimationClip attackAnimation;
	public new Animation animation;
	public static bool isAttacking;

	/*
	public string name;
	public int health;
	public int damage;
	public float range;
	*/
	public static Transform opponent;	//Name after the "Enemy" Script. //opponent is the reference.		
	//public static can be accesed without having script access.


	// Awake: Called Before start. 
	void Awake () 
	{
		player = this;
		animation = GetComponent<Animation> ();
		isAttacking = false;
	}


	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		Attack();
		//Debug.Log (isAttacking);
		//Debug.Log (health);

	}


	//New Method/Function. This Method will be used for the player's attacking.
	protected override void Attack()
	{
		//Debug.Log ("Player is Attacking");

		if(isAttacking == false)
		{
			if (Input.GetKeyUp (KeyCode.Space)) 
			{
				
				//if Enemy is within attack range AND an opponent is selected.
				if(opponent != null && Vector3.Distance (opponent.position, transform.position) < range)
				{
					//Debug.Log ("Player Attacked!");
					isAttacking = true;
					opponent.GetComponent<Enemy>().GetHit(damage);
					animation.CrossFade (attackAnimation.name);	//crossfade blends animations instead of playing immediaty.
					Invoke ("UnBlock", attack_Speed); //call function after set amount of time.
					//Enemy.GetHit(damage);
				}
				
			}
		}


		if(!animation.IsPlaying (attackAnimation.name))
		{
			isAttacking = false;
		}

	}

	void UnBlock()
	{
		isAttacking = false;
	}

}
