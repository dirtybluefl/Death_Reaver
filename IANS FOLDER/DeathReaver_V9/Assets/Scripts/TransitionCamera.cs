using UnityEngine;
using System.Collections;

//This function simply sets the current game level to the given value.
public class TransitionCamera: MonoBehaviour 
{
	//Define Variables:
	//public TransitionCamera transitionCamera;
	GameObject target;
	bool initial_Pause = true;
	bool camera_Position = false;
	//Transition to position overtime:
	public Transform startMarker;
	public Transform endMarker;
	public float speed = 1.0F;
	private float startTime;
	private float journeyLength;

	// Use this for initialization
	void Start () 
	{




	}


	public void activate_Transition()
	{
		if(CameraControl.game_Level == 1)
		{
			print ("Transitioning for Level 1 Survival Mode");
			//print (CameraControl.game_Paused);
			//scene1_Transition();
			Invoke("enable_Game", 2);	//seconds
			//print (CameraControl.game_Paused);
		}
		
		else if(CameraControl.game_Level == 2)
		{
			print ("Transitioning for Level 2 Museum Interior LAB ROOM");
			Invoke("enable_Game", 0);	//seconds
		}

		else if(CameraControl.game_Level == 3)
		{
			print ("Transitioning for Level 3 Museum Interior");
			Invoke("enable_Game", 0);	//seconds
		}
		
		else if(CameraControl.game_Level == 4)
		{
			print ("Transitioning for Level 4 Museum Exterior");
			Invoke("enable_Game", 0);	//seconds
		}
	}


	public void scene1_Transition()
	{
		//print ("1");
		startTime = Time.time;
		journeyLength = Vector3.Distance(startMarker.position, endMarker.position);

		print ("1");

		if(initial_Pause == true)
		{
			print ("2");
			//Debug.Log ("Initial Pause is false");
			if (camera_Position == false) 
			{
				print ("3");
				//Debug.Log ("Not yet in position");
				//transition camera to new location over time:


				Invoke("move_Camera", 0.5f);	//seconds


				
				
				
				if(transform.position == endMarker.position)
				{
					print ("4");
					//Debug.Log ("Target reached");
					camera_Position = true;
					CameraControl.game_Paused = false;
				}
			}
		}

	}


	void scene2_Transition()
	{
		
	}


	void scene3_Transition()
	{
		
	}




	public void enable_Game()
	{
		Debug.Log ("Game no longer paused");
		CameraControl.game_Paused = false;
	}


}
