using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Soul_Text : MonoBehaviour 
{
	//Used for Debug purposes to see how many souls the player has collected:
	
	//Define Variables:
	//UnityEngine.UI.Text soulsCollected;
	public GameObject soulStatus;
	Text text;
	
	
	// Use this for initialization
	void Start () 
	{
		text = soulStatus.GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () 
	{
		text.text = "( " + (Mathf.Round(Player_SoulBar.current_Souls).ToString()) + " / " + (Mathf.Round(Player_SoulBar.new_MaxSouls).ToString()) + " )"; 

	}
}
