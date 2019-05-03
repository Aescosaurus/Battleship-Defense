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

		shotRefire = gameObject.AddComponent<Timer>();
		shotRefire.Duration = refireTime;
	}

	void Update()
	{
		if (Input.GetAxis("Fire") > 0.0f &&
			shotRefire.IsDone)
		{
			shotRefire.Reset();

			var bullet = Instantiate(bulletPrefab,
				transform.position,
				cam.transform.rotation);

			bullet.GetComponent<BulletMove>()
				.SetVel(bulletVel);
			bullet.GetComponent<Damager>()
				.SetDamage(damage);
		}
	}
	#endregion

	#region members
	Transform bulletSpawnLoc;
	GameObject bulletPrefab;
	[SerializeField] float bulletVel = 2.0f;
	Camera cam;
	[SerializeField] float refireTime = 1.0f;
	Timer shotRefire;
	[SerializeField] int damage;
	#endregion
}
