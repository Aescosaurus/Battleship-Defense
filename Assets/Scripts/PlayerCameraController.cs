using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class PlayerCameraController
	:
	MonoBehaviour
{
	#region methods
	void Start()
	{
		player = GameObject.FindGameObjectWithTag("Player");
		Assert.IsNotNull(player);
	}

	void Update()
	{
		if (Input.GetAxis("Fire2") > 0.0f)
		{
			transform.eulerAngles = new Vector3(
				transform.eulerAngles.x - Input.GetAxis(
					"Mouse Y") * rotationSpeed * Time.deltaTime,
				transform.eulerAngles.y + Input.GetAxis(
					"Mouse X") * rotationSpeed * Time.deltaTime,
				transform.eulerAngles.z);
		}

		transform.position = player.transform.position;
		transform.position -= transform.forward * minDistToPlayer;
	}
	#endregion

	#region members
	[SerializeField] float minDistToPlayer = 4.0f;
	[SerializeField] float rotationSpeed = 100.0f;

	GameObject player;
	#endregion
}
