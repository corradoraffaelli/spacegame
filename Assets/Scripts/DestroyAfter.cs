using UnityEngine;
using System.Collections;

public class DestroyAfter : MonoBehaviour {

	float creationTime = 0.0f;
	public float destroyAfter = 4.0f;

	void Start () {
		creationTime = Time.time;
		StartCoroutine (DelayedDestroy ());
	}

	IEnumerator DelayedDestroy()
	{
		yield return new WaitForSeconds (destroyAfter);
		Destroy (gameObject);
	}

}
