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
			transform.rotation = Quaternion.Euler(0.0f,
				cam.transform.eulerAngles.y,
				0.0f);

			transform.Translate(
				xMove * moveSpeed * Time.deltaTime,
				0.0f,
				yMove * moveSpeed * Time.deltaTime);
		}
	}
	#endregion

	#region members
	[SerializeField] float moveSpeed = 4.5f;

	Camera cam;
	#endregion
}
