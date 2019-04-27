using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class PlayerMovement
	:
	MonoBehaviour
{
	#region methods
	void Start()
	{
		cam = Camera.main;
		Assert.IsNotNull(cam);
	}

	void Update()
	{

	}
	#endregion

	#region members
	Camera cam;
	#endregion
}
