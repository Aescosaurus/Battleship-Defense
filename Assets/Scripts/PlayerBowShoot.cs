using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class PlayerBowShoot
	:
	MonoBehaviour
{
	#region methods
	void Start()
	{
		bulletSpawnLoc = transform.Find("BulletSpawnPos");
		Assert.IsNotNull(bulletSpawnLoc);

		bulletPrefab = Resources.Load<GameObject>(
			"Prefabs/Bullet");
		Assert.IsNotNull(bulletPrefab);

		cam = Camera.main;
		Assert.IsNotNull(cam);
	}

	void Update()
	{
		if (Input.GetAxis("Fire") > 0.0f)
		{
			var bullet = Instantiate(bulletPrefab,
				transform.position,
				cam.transform.rotation);

			bullet.GetComponent<PlayerBulletMove>()
				.SetVel(bulletVel);
		}
	}
	#endregion

	#region members
	Transform bulletSpawnLoc;
	GameObject bulletPrefab;
	[SerializeField] float bulletVel = 2.0f;
	Camera cam;
	#endregion
}
