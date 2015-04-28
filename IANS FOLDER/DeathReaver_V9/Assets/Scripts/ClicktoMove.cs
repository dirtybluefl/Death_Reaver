using UnityEngine;
using System.Collections;

public class ClicktoMove : MonoBehaviour {

	//Define Variables:
	NavMeshAgent navAgent;
	public AnimationClip runAnimation;
	public AnimationClip idleAnimation;
	new Animation animation;
	float warp_Range = 12;  //range of warp Talent AOE.
	float warp_Damage = 150;  //Damage of warp Talent AOE.

	// Use this for initialization
	void Awake () 
	{
		//Initialize Stuff:
		navAgent = GetComponent<NavMeshAgent> ();	//Retrieves info from NavMeshAgent navAgent.
		animation = GetComponent<Animation> ();
		
		//Debug Statement shown in console.
		//Debug.Log ("Function Started!, DEBUGGING YAY!");
		
	}




	// Use this for initialization
	void Start () 
	{


	}
	
	// Update is called once per frame
	void Update () 
	{

		if (CameraControl.game_Paused == false) 
		{
			//Debug.Log ("Function Updated");

				Move (); //Calls the Move Function.




			Animate();
			player_Block();
		}

	}


	//This Function moves the player to the clicked mouse location.
	void Move()
	{
		RaycastHit hit; //Hold Information for point location where ray from camera view hits terrain.
		Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
		//Initialize basic speed:
		//navAgent.speed = 8;

		//otherwise act normal.

			if(Player2.isBlocking == false)
			{
				//If Player is NOT attacking then player can move:
				if(Player2.isAttacking == false)
				{
					if(Player2.isRolling == false)
					{
						//Blocks clicking when over a gui element.
						if(!UnityEngine.EventSystems.EventSystem.current.IsPointerOverGameObject())
						{
							if(Input.GetMouseButton(0)) //0 is left mouse button.
							{
								//print ("CAN MOVE");
								if(Physics.Raycast (ray, out hit, 1000))	//Distance 100, stores in HIT, length of the ray is 100.
								{
									//Debug.Log (hit.point);
									
									//print ("RAY CAST HIT LOCATION: " + hit.point);
									if(Player2.ability_WarpActive == true)
									{
										print ("did warp work?");
										navAgent.Warp (hit.point);
										cause_Warp_Damage(transform.position, warp_Range);
										Player2.ability_WarpActive = false;
									}

									else if(Player2.ability_WarpActive == false)
									{
										navAgent.SetDestination (hit.point);
									}

									
									
									//if rolling occurs, set destination to... null?
								}
							}
						}
						
					}
					
					else if (Player2.isRolling == true)
					{
						//print ("CAN'T MOVE");
						navAgent.ResetPath();
					}
				}
				
				else if(Player2.isAttacking == true)
				{
					navAgent.ResetPath();
				}
			}
			
			else if(Player2.isBlocking == true)
			{
				navAgent.ResetPath();
			}
	}














	void Animate()
	{
		if(!Player2.isAttacking)
		{
			//If velocity is > 0.5f play run animation, less peed play walk speed, else no speed then play idle.
			if (navAgent.velocity.magnitude > 0.5f) 
			{	//velocity is speed AND direction, we just want magnitude/speed.
				animation.CrossFade (runAnimation.name);
			} 
			else 
			{
				animation.CrossFade (idleAnimation.name);
			}
		}


	}


	//Player BLOCK Function:
	public void player_Block()
	{
		//print ("BLOCKING STATUS");
		//print (Player2.isBlocking);

		if (Player2.isRolling == false) 
		{
			if(Player2.isAttacking == false)
			{
				if (Input.GetMouseButton (1)) 
				{
					navAgent.ResetPath();
					//ENABLE BLOCKING:
					//Play blocking animation.
					//print ("BLOCKING!!!");
					Player2.isBlocking = true;
					
				} 
			}
		}

		if (!Input.GetMouseButton (1)) 
		{
			//print ("no more blocking");
			Player2.isBlocking = false;
		}
	}



	public void cause_Warp_Damage(Vector3 center, float radius)
	{
		print ("Warp AOE Damage");
		Collider[] hitColliders = Physics.OverlapSphere(center, radius);
		int i = 0;
		while (i < hitColliders.Length) 
		{
			hitColliders [i].SendMessage("takeWarpDamage",warp_Damage,SendMessageOptions.DontRequireReceiver);
			//SendMessage("StalwartDamage", stalwart_Damage, SendMessageOptions.DontRequireReceiver);
			i++;
		}
	}











}
