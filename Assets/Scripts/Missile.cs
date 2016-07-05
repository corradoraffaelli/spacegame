using UnityEngine;
using System.Collections;

public class Missile : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.tag == EditorKeys.TAG_OBSTACLE) {
			Obstacle obst = other.gameObject.GetComponent<Obstacle> ();
			if (obst != null)
				obst.DestroyMe ();
		}
	}
}
