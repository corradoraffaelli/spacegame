using UnityEngine;
using System.Collections;

public class Obstacle : MonoBehaviour {

	public GameObject standardGraphic;
	public GameObject deathParticles;

	public void DestroyMe()
	{
		if (deathParticles != null)
			deathParticles.SetActive (true);

		if (standardGraphic != null)
			standardGraphic.SetActive (false);

		BoxCollider2D obstCollider = GetComponent<BoxCollider2D> ();
		obstCollider.enabled = false;
	}

}
