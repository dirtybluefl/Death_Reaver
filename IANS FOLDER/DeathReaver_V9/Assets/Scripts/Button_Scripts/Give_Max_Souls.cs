using UnityEngine;
using System.Collections;

public class Give_Max_Souls : MonoBehaviour 
{

	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}


	//When button is clicked, player is given max souls for debug/presentation purposes.
	//OnMouseClick:
	public void MouseClick()
	{
		//print ("player now has max souls");
		//print ("Player current Souls 1:  " + Player_SoulBar.current_Souls);
		//print ("Player Max Souls:  " + Player_SoulBar.new_MaxSouls);

		Player_SoulBar.current_Souls = Player2.level4_Unlock;
		//print ("Player current Souls 2:  " + Player_SoulBar.current_Souls);
		
	}   


}
