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

	void FixedUpdate()
	{
		if (move) {
			float speedMultiplier = 1.0f;
			if (fingerPoint.transform.localPosition.y < 0.0f)
				speedMultiplier = -1.0f;

			float relSpeed = Vector2.Dot (rigBody.velocity, new Vector2 (transform.up.x, transform.up.y));
				
			if ((relSpeed < 0.5f && speedMultiplier > 0.0f) || (relSpeed > 0.5f && speedMultiplier < 0.0f))
				rigBody.AddRelativeForce (Vector2.up * enginePower * speedMultiplier);

			float multiplier = 1.0f;
			if (fingerPoint.transform.localPosition.x > 0.0f)
				multiplier = -1.0f;

			//TODO: torque relative to the difference between angles, if angle is little, torque little

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
