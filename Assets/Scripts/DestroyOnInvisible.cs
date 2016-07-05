using UnityEngine;
using System.Collections;

public class DestroyOnInvisible : MonoBehaviour {

	public bool enabled = true;

	void OnBecameInvisible()
	{
		if (enabled)
			Destroy (gameObject);
	}
}
