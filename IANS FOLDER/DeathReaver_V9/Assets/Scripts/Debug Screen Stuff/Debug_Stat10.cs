using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Debug_Stat10 : MonoBehaviour 
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
		text.text = "Player Chose Talent Tier 4:                  " + (Player2.chose_Tier3Talent);

	}
}
