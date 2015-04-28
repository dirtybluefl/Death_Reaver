using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Armor_Pickup : MonoBehaviour
{
	//Define Variables:
	//CameraControl camera_Control;
	Player2 player;




	Transform transformTest;








	// Use this for initialization
	void Awake () 
	{
		player = Player2.player;




		transformTest = GetComponent<Transform> ();

	




	

	}
	
	
	// Use this for initialization
	void Start () 
	{

		player = Player2.player;
	

	}
	
	// Update is called once per frame
	void Update () 
	{

		GivePlayerArmor ();

		if(player.playerHasArmor == true)
		{

			transform.position = new Vector3(-2000, -2000, -2000);
		}

	}





















	//Aggro Range. Check to see if player is close enough to start following.
	void GivePlayerArmor()
	{
		if (Vector3.Distance (player.transform.position, transform.position) < 5) 
		{
			player.playerHasArmor = true;
			destroyObject();
			print (player.playerHasArmor);
			//return true;
		} 

		else 
		{
			//return false;
		}
	}






		
	


	public void destroyObject()
	{
		Destroy(this, 1f);		
	}

	

}
