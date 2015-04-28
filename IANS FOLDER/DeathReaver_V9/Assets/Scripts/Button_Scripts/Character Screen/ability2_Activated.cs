using UnityEngine;
using System.Collections;


public class ability2_Activated : MonoBehaviour 
{
	//Define Variables:
	//public int assign_WeaponOption;		//assign value of 1, 2 or 3 to sync with weapon choice.
	CanvasGroup cg;
	public Player2 player;

	// Use this for initialization
	void Start () 
	{
		cg = this.GetComponent<CanvasGroup>();
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(player.ability_ReaverActive == true)
		{
			//gameObject.SetActive(true);
			//print("should be shown");
			cg.alpha = 1;

		}

		//Hide when NOT selected.
		else if(player.ability_ReaverActive == false)
		{
			//gameObject.SetActive(false);
			//print("should not be shown");
			cg.alpha = 0;

		}




	}
}
