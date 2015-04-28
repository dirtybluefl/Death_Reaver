using UnityEngine;
using System.Collections;

public class Exit_Game : MonoBehaviour 
{

	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}

	//OnMouseClick:
	public void MouseClick()
	{
		// this object was clicked - do something
		Debug.Log ("Game Quit");

		//Close the Game Program:
		Application.Quit();
	}   




}
