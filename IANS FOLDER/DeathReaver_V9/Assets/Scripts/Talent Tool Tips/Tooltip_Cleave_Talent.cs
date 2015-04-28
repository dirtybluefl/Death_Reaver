using UnityEngine;
using System.Collections;

public class Tooltip_Cleave_Talent : MonoBehaviour 
{
	//Define Variables:
	CanvasGroup cg;


	// Use this for initialization
	void Start () 
	{
		cg = this.GetComponent<CanvasGroup>();
		cg.blocksRaycasts = false;
		cg.alpha = 0;	//hide initially.
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}

	//Shows Tooltip:
	public void show_Tooltip()
	{
		cg.alpha = 1;
	}

	//Hides Tooltip:
	public void hide_Tooltip()
	{
		cg.alpha = 0;
	}






}
