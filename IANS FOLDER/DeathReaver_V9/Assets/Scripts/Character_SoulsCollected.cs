using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Character_SoulsCollected : MonoBehaviour 
{
	//Used for Debug purposes to see how many souls the player has collected:

	//Define Variables:
	//UnityEngine.UI.Text soulsCollected;
	public GameObject soulsCollected;
	Text text;


	// Use this for initialization
	void Start () 
	{
		text = soulsCollected.GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () 
	{
		text.text = "Total Souls Collected: " + Player_SoulBar.current_Souls; 
	}
}
