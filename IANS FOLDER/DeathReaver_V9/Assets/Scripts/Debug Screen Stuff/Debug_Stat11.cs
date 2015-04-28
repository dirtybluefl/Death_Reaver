using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Debug_Stat11 : MonoBehaviour 
{
	//Used for Debug purposes to see how many souls the player has collected:
	
	//Define Variables:
	//UnityEngine.UI.Text soulsCollected;
	public GameObject current_Stat;
	Text text;
	//public Player2 player;
	
	// Use this for initialization
	void Start () 
	{
		text = current_Stat.GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (Player2.weapon_Specialization == 1) 
		{
			text.text = "Weapon Specialization:                          (Mace Specialization)" + (Player2.weapon_Specialization).ToString ();
		} 

		else if (Player2.weapon_Specialization == 2) 
		{
			text.text = "Weapon Specialization:                          (Sword Specialization)" + (Player2.weapon_Specialization).ToString ();
		} 

		else if (Player2.weapon_Specialization == 3) 
		{
			text.text = "Weapon Specialization:                          (Staff Specialization)" + (Player2.weapon_Specialization).ToString ();
		} 

		else 
		{
			text.text = "Weapon Specialization:                          (NONE)" + (Player2.weapon_Specialization).ToString ();
		}


	}
}
