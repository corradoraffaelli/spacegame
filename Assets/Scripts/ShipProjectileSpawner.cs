using UnityEngine;
using System.Collections;

public class ShipProjectileSpawner : MonoBehaviour {

	public GameObject missile;
	public GameObject shipPoint;
	GameObject spawnedMissile;

	float lastShoot = -Mathf.Infinity;
	public float timeBetweenShoot = 0.5f;

	bool missileMustStart = false;

	public float missileForce = 2.0f; 

	public void Shoot()
	{
		bool canShoot = ((Time.time - lastShoot) > timeBetweenShoot);

		if (canShoot)
		{
			lastShoot = Time.time;
			if (missile != null && shipPoint != null) {
				spawnedMissile = Instantiate (missile, shipPoint.transform.position, shipPoint.transform.rotation) as GameObject;
				missileMustStart = true;
			}
		}
	}

	void FixedUpdate()
	{
		if (missileMustStart && spawnedMissile != null) {
			GiveForceToMissile (spawnedMissile);
			missileMustStart = false;
		}
	}

	void GiveForceToMissile(GameObject missile)
	{
		Rigidbody2D missileRigidbody = missile.GetComponent<Rigidbody2D> ();
		Vector3 missileDirection = spawnedMissile.transform.up;

		if (missileRigidbody != null)
			missileRigidbody.AddForce (new Vector2 (missileDirection.x * missileForce, missileDirection.y * missileForce));
	}
}
