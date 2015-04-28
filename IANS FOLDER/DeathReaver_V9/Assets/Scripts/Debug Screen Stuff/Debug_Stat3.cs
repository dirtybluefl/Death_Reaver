using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Debug_Stat3 : MonoBehaviour 
{
	//Used for Debug purposes to see how many souls the player has collected:
	
	//Define Variables:
	//UnityEngine.UI.Text soulsCollected;
	public GameObject current_Stat;
	Text text;
	
	
	// Use this for initialization
	void Start () 
	{
		text = current_Stat.GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () 
	{
		text.text = "Current Souls:                            " + (Mathf.Round(Player_SoulBar.current_Souls).ToString());

	}
}
