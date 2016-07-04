using UnityEngine;
using System.Collections;

public class ShipMovements : MonoBehaviour {

	public GameObject fingerPoint;

	bool move = false;
	Vector3 positionToReach = Vector3.zero;

	public float rotationSpeed = 1.0f;
	public float enginePower = 3.0f;

	Rigidbody2D rigBody;

	float playerZ;


	public float maxAngularVelocity = 20.0f;

	void Awake()
	{
		rigBody = GetComponent<Rigidbody2D> ();
		playerZ = transform.position.z;
	}

	void Update()
	{
		if (move) {

		}
	}

	void FixedUpdate()
	{
		if (move) {
			rigBody.AddRelativeForce (Vector2.up * enginePower);

			float multiplier = 1.0f;
			if (fingerPoint.transform.localPosition.x > 0.0f)
				multiplier = -1.0f;



			bool negativeExcedeed = multiplier < 0 && rigBody.angularVelocity < -maxAngularVelocity;
			bool positiveExcedeed = multiplier > 0 && rigBody.angularVelocity > maxAngularVelocity;

			if (!negativeExcedeed && !positiveExcedeed)
				rigBody.AddTorque(Time.deltaTime * rotationSpeed * multiplier);
		}
	}

	public void TryReachPosition(Vector3 positionToReach)
	{
		move = true;
		this.positionToReach = positionToReach;
		fingerPoint.transform.position = positionToReach;
	}

	public void TryReachPosition(Vector2 screenPositionToReach)
	{
		Vector3 pos = Camera.main.ScreenToWorldPoint (screenPositionToReach);
		pos.z = playerZ;
		TryReachPosition (pos);
	}

	public void DontReachPosition()
	{
		move = false;
	}
}
