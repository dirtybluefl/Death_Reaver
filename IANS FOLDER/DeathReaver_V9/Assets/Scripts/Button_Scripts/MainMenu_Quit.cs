using UnityEngine;
using System.Collections;

public class MainMenu_Quit : MonoBehaviour 
{
	
	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}
	
	//RESETS all of the chosen talents/skills when clicked.
	//OnMouseClick:
	public void MouseClick()
	{
		Application.LoadLevel ("MainMenu"); 
		
	}   
	
	
	
}
