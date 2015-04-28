using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Health_Text : MonoBehaviour 
{
	//Used for Debug purposes to see how many souls the player has collected:
	
	//Define Variables:
	//UnityEngine.UI.Text soulsCollected;
	public GameObject healthStatus;
	Text text;
	
	
	// Use this for initialization
	void Start () 
	{
		text = healthStatus.GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () 
	{



		text.text = "( " + (Mathf.Round(Player2.health).ToString()) + " / " + (Mathf.Round(Player2.max_Health).ToString()) + " )"; 

	}
}
