using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class BasicGun
	:
	MonoBehaviour
{
	#region methods
	void Start()
	{
		cam = Camera.main;
		Assert.IsNotNull(cam);

		player = GameObject.FindGameObjectWithTag("Player");
		Assert.IsNotNull(player);

		playerMoveScript = player.GetComponent<PlayerMovement>();
		Assert.IsNotNull(playerMoveScript);

		playerStandPos = transform.Find("PlayerPos");
		Assert.IsNotNull(playerStandPos);
	}

	void Update()
	{
		if (Input.GetAxis("Fire") > 0.0f &&
			(player.transform.position - transform.position)
			.sqrMagnitude <= minActivationDistSq)
		{
			RaycastHit hit;
			Ray ray = cam.ScreenPointToRay(Input.mousePosition);

			if (Physics.Raycast(ray, out hit))
			{
				if (hit.transform.gameObject.layer ==
					LayerMask.NameToLayer("Gun"))
				{
					manned = true;
					playerMoveScript.ToggleEnabled(false);
				}
			}
		}

		// if exit button pressed
		//  manned = false
		//  playerMoveScript.ToggleEnabled( true )

		if (manned)
		{
			player.transform.position = playerStandPos.position;
		}
	}
	#endregion

	#region members
	const float minActivationDistSq = 2.0f * 2.0f;
	Camera cam;
	GameObject player;
	PlayerMovement playerMoveScript;
	Transform playerStandPos;
	bool manned;
	#endregion
}
