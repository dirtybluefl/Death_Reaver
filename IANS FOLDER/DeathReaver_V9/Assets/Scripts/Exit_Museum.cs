using UnityEngine;
using System.Collections;

public class Exit_Museum : MonoBehaviour 
{
	//Define Variables:
	public GameObject player;
	public Player2 player_script;
	Transform transformTest;
	public CameraControl cameraControl;

	// Use this for initialization
	void Start () 
	{
		transformTest = GetComponent<Transform> ();
		//print (player_script.playerHasArmor);
	}
	
	// Update is called once per frame
	void Update () 
	{
		leave_Museum ();
	}

	void leave_Museum()
	{
		//print ("grr?");
		if (Vector3.Distance (player_script.transform.position, transform.position) < 10) 
		{


			if (player_script.playerHasArmor == true)
			{
				//application load level.
				print ("leaving museum");
				cameraControl.save_Stats();
				Application.LoadLevel ("Main_Museum_Exterior"); 
			}

		} 
		

	}




}
