using UnityEngine;
using System.Collections;

public abstract class Creature_Class : MonoBehaviour 
{
		public new string name;
		public int health;
		public int damage;
		public float range;
		public float attack_Speed = 2.5f;	//per second.



	// hit by external target.
	public void GetHit(int playerDamage)
	{
		
		health = health - playerDamage;	//health minus player's damage amount.
		Debug.Log (health);	//show the enemy's new health.
		
	}

	protected abstract void Attack();
}

/*Inheritance Notes:
 * we can have a class inherit another class to save time re-making similar code.
 * //Protected type means function can ONLY be seen by itself and the child classes inherited.
 * //abstract means class cannot be created, can only be inherited and the copies are worked with.
 * Purpose is to require each creature class to have an attack method. (I personaly find this annoying but what do I know)
 * */