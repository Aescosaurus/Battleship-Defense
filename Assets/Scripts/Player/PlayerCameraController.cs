﻿using System.Collections;
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

		distToPlayer = (minDistToPlayer +
			maxDistToPlayer) / 2.0f;
		playerPosAdd = new Vector3(0.0f, heightAbovePlayer,
			0.0f);
	}

	void Update()
	{
		Cursor.lockState = CursorLockMode.Locked;

		// if (Input.GetAxis("Rotate Camera") > 0.0f)
		{
			transform.eulerAngles = new Vector3(
				transform.eulerAngles.x - Input.GetAxis(
					"Mouse Y") * rotationSpeed * Time.deltaTime,
				transform.eulerAngles.y + Input.GetAxis(
					"Mouse X") * rotationSpeed * Time.deltaTime,
				transform.eulerAngles.z);
		}

		distToPlayer -= Input.GetAxis("Mouse ScrollWheel") *
			scrollSpeed * Time.deltaTime;

		distToPlayer = Mathf.Max(minDistToPlayer, distToPlayer);
		distToPlayer = Mathf.Min(maxDistToPlayer, distToPlayer);

		transform.position = player.transform.position +
			playerPosAdd;
		transform.position -= transform.forward * distToPlayer;
	}
	#endregion

	#region members
	[SerializeField] float minDistToPlayer = 4.0f;
	[SerializeField] float maxDistToPlayer = 6.0f;
	[SerializeField] float heightAbovePlayer = 1.0f;
	float distToPlayer;
	Vector3 playerPosAdd;

	[SerializeField] float rotationSpeed = 100.0f;
	[SerializeField] float scrollSpeed = 50.0f;

	GameObject player;
	#endregion
}
