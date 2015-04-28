using UnityEngine;
using System.Collections;


//Attached to end game object on scene 3 Museum Exterior, when player enters object area, ends game.
public class EndGame : MonoBehaviour 
{
	//Define Variables:
	MeshRenderer mesh;

	// Use this for initialization
	void Start () 
	{
		//disable visibility.
		renderer.enabled = false;
	}
	
	// Update is called once per frame
	void Update () 
	{
		player_EndGame ();

	}



	//Detects when player enters area, then ends game:
	public void player_EndGame()
	{


	}


	//detects when an object collides inside this object, other objects need rigidbodies added to detect collision, but can have
	// physics turned off with "is kinematic".
	void OnTriggerEnter(Collider other) 
	{
		Debug.Log ("OnTriggerEnter : other.tag = " + other.tag); // shows the tag of the trigger
		// if tag is door
		if (other.tag == "Player")
		{
			print ("GAME WIN!!!");


			//for now goes back to main menu.
			Application.LoadLevel ("MainMenu"); 
		}
	}


	
	
	
}
