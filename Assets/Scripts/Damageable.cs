using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damageable
	:
	MonoBehaviour
{
	#region methods
	void Start()
	{
		health = maxHealth;
	}

	void OnCollisionEnter(Collision coll)
	{
		var damagerScript = coll.gameObject.GetComponent<
			Damager>();
		if (damagerScript != null)
		{
			health -= damagerScript.GetDamage();
		}
	}
	#endregion

	#region members
	[SerializeField] int maxHealth;
	int health;
	#endregion
}
