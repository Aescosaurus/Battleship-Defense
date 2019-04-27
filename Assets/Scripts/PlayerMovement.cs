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
		var xMove = Input.GetAxis("Horizontal");
		var yMove = Input.GetAxis("Vertical");

		if (xMove != 0.0f || yMove != 0.0f)
		{
			// Calculate sprint speed multiplier.
			var sprintMod = 1.0f;
			if( Input.GetAxis( "Fire3" ) > 0.0f )
			{
				sprintMod = sprintSpeedModifier;
			}

			// Rotate same as the camera.
			transform.rotation = Quaternion.Euler(0.0f,
				cam.transform.eulerAngles.y,
				0.0f);

			// Move based on look direction.
			transform.Translate(
				xMove * moveSpeed * sprintMod * Time.deltaTime,
				0.0f,
				yMove * moveSpeed * sprintMod * Time.deltaTime);
		}
	}
	#endregion

	#region members
	[SerializeField] float moveSpeed = 4.5f;
	[SerializeField] float sprintSpeedModifier = 2.0f;

	Camera cam;
	#endregion
}
