using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMove
	:
	MonoBehaviour
{
	#region methods
	void Update()
	{
		transform.position += transform.forward *
			vel * Time.deltaTime;
	}

	public void SetVel(float vel)
	{
		this.vel = vel;
	}

	void OnCollisionEnter( Collision coll )
	{
		Destroy(gameObject);
	}
	#endregion

	#region members
	float vel;
	#endregion
}
