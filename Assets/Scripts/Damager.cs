using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damager
	:
	MonoBehaviour
{
	#region methods
	public void SetDamage(int damage)
	{
		this.damage = damage;
	}
	public int GetDamage()
	{
		return damage;
	}
	#endregion

	#region members
	[SerializeField] int damage;
	#endregion
}
