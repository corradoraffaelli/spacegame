using UnityEngine;
using System.Collections;

public class ObstacleSpawner : MonoBehaviour {

	public GameObject spawner;

	BoxCollider2D spawnerCollider;

	public float timeBetweenSpawn = 3.0f;

	void Start()
	{
		spawnerCollider = GetComponent<BoxCollider2D> ();
	}

}
