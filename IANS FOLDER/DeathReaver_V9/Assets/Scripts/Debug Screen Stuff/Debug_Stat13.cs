using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Debug_Stat13 : MonoBehaviour 
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
		if (Player2.tier2_Talent == 1) 
		{
			//Could replace with strings to define names of each talent rather than having to type it out manually, later update.
			text.text = "Tier 2 Talent Chosen:                          (Charge Talent)" + (Player2.tier2_Talent).ToString ();
		} 

		else if (Player2.tier2_Talent == 2) 
		{
			text.text = "Tier 2 Talent Chosen:                          (Drive Talent)" + (Player2.tier2_Talent).ToString ();
		} 

		else if (Player2.tier2_Talent == 3) 
		{
			text.text = "Tier 2 Talent Chosen:                          (Stalwart Talent)" + (Player2.tier2_Talent).ToString ();
		} 

		else 
		{
			text.text = "Tier 2 Talent Chosen:                          (NONE)" + (Player2.tier2_Talent).ToString ();
		}


	}
}
