using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Debug_Stat14 : MonoBehaviour 
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
		if (Player2.tier3_Talent == 1) 
		{
			//Could replace with strings to define names of each talent rather than having to type it out manually, later update.
			text.text = "Tier 3 Talent Chosen:                          (Unbreakable Talent)" + (Player2.tier3_Talent).ToString ();
		} 

		else if (Player2.tier3_Talent == 2) 
		{
			text.text = "Tier 3 Talent Chosen:                          (Warp Talent)" + (Player2.tier3_Talent).ToString ();
		} 

		else if (Player2.tier3_Talent == 3) 
		{
			text.text = "Tier 3 Talent Chosen:                          (Reaver Talent)" + (Player2.tier3_Talent).ToString ();
		} 

		else 
		{
			text.text = "Tier 3 Talent Chosen:                          (NONE)" + (Player2.tier3_Talent).ToString ();
		}


	}
}
