using UnityEngine;
using System.Collections;


//This will handle the moving forward of the shockwave object, and destroying it after set time.
public class Drive_Shockwave : MonoBehaviour 
{
	//Define Variables:
	float shockwave_Speed = 0.5f;


	// Use this for initialization
	void Start () 
	{

	}
	
	// Update is called once per frame
	void Update () 
	{
		if (CameraControl.game_Paused == false) 
		{
			Invoke("destroy_This", 0.7f);
			launch_Shockwave ();
		}


	}


	//Function for The Player's Drive Talent.
	public void launch_Shockwave()
	{
		//print ("shockwave active");
		this.transform.Translate(Vector3.forward * shockwave_Speed, Space.Self);


	}

	//Function for The Player's Drive Talent.
	public void destroy_This()
	{
		print ("object destroyed");
		Destroy(this.gameObject);
		
	}

	//Detects when enemy is hit by the Player DRIVE shockwave talent:
	void OnTriggerEnter(Collider other) 
	{
		//if projectile runs into a solid object, destroy it, prevents going through walls and stuff.
		if (other.tag.Contains("Solid_Object"))
		{
			print ("HIT A WALL, OOPS!");
			Destroy(this.gameObject);
			
		}
		
		

		//When hitting a stationary wall/obstacle object, destroy this object.
		//REFERENCE: MULTIPLE TAGS ON OBJECT, one tag with multiple identifiers, such as fire_ice_water, contains "fire", ta da
		//example tag that works: Solid_Object_fire_ice
		/*
		if (other.tag.Contains("fire"))
		{
			print ("HIT A WALL, OOPS!");
			Destroy(this.gameObject);
			
		}
		*/

	}

}




