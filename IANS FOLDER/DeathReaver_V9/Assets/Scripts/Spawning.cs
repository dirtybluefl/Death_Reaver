using UnityEngine;
using System.Collections;

public class Spawning : MonoBehaviour 
{
	//Define Variables:

	public Player2 player;
	public GameObject enemy_Type1;
	public GameObject new_Enemy_Type1;
	public GameObject spawnPoint_1;
	public Transform[] spawnPoints; 
	public float spawnTime = 3f;  
	//Enemy_HealthBar enemy_HealthBar;




	// Use this for initialization
	void Start () 
	{
		player = Player2.player;
		InvokeRepeating ("Spawn", spawnTime, spawnTime);





	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}

	void Spawn ()
	{
		if (CameraControl.game_Paused == false) 
		{
			// If the player has no health left...
			if(Player2.health <= 0f)
			{
				// ... exit the function.
				//return;		//UNCOMMENT TO RE-ENABLE SPAWNING DISABLE ON DEATH OF PLAYER.
			}
			
			// Find a random index between zero and one less than the number of spawn points.
			int spawnPointIndex = Random.Range (0, spawnPoints.Length);
			
			// Create an instance of the enemy prefab at the randomly selected spawn point's position and rotation.
			//Instantiate (enemy_Type1, spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);
			//Creates a new INSTANCE of the Enemy1x Enemy, and gives it a name to remove the (Clone) that is added to cloned object name.
			new_Enemy_Type1 = (GameObject)Instantiate (enemy_Type1, spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);
			new_Enemy_Type1.name = enemy_Type1.name;
		}

	}
}
