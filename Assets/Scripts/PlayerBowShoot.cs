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
	}

	void Update()
	{
		if (Input.GetAxis("Fire") > 0.0f)
		{
			var bullet = Instantiate(bulletPrefab,
				transform.position, transform.rotation);
			bullet.GetComponent<PlayerBulletMove>()
				.SetVel(bulletVel);
		}
	}
	#endregion

	#region members
	Transform bulletSpawnLoc;
	GameObject bulletPrefab;
	[SerializeField] float bulletVel = 2.0f;
	#endregion
}
