using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer
	:
	MonoBehaviour
{
	#region properties 
	public float Duration
	{
		get
		{
			return maxTime;
		}
		set
		{
			maxTime = value;
		}
	}
	public bool IsDone
	{
		get
		{
			return curTime >= maxTime;
		}
	}
	#endregion

	#region methods
	void Update()
	{
		if( curTime <= maxTime )
		{
			curTime += Time.deltaTime;
		}
	}

	public void Reset()
	{
		curTime = 0.0f;
	}
	#endregion

	#region members
	float curTime = 0.0f;
	float maxTime;
	#endregion
}
