using UnityEngine;
using System.Collections;


public class selected_Tier2 : MonoBehaviour 
{
	//Define Variables:
	public int assign_Tier2Option;		//assign value of 1, 2 or 3 to sync with weapon choice.
	CanvasGroup cg;


	// Use this for initialization
	void Start () 
	{
		cg = this.GetComponent<CanvasGroup>();
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(Player2.tier2_Talent == assign_Tier2Option)
		{
			//gameObject.SetActive(true);
			//print("should be shown");
			cg.alpha = 1;

		}

		//Hide when NOT selected.
		else if(Player2.tier2_Talent != assign_Tier2Option)
		{
			//gameObject.SetActive(false);
			//print("should not be shown");
			cg.alpha = 0;

		}




	}
}
