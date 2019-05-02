using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBulletMove
	:
	MonoBehaviour
{
	#region methods
	void Update()
	{
		transform.Translate(transform.forward *
			vel * Time.deltaTime);
	}

	public void SetVel( float vel )
	{
		this.vel = vel;
	}
	#endregion

	#region members
	float vel;
	#endregion
}
