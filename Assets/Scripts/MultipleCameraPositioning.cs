using UnityEngine;
using System.Collections;

public class MultipleCameraPositioning : MonoBehaviour {

	public GameObject rightCamera;
	public GameObject leftCamera;
	public GameObject upCamera;
	public GameObject downCamera;

	void Awake()
	{
		Camera mainCamera = Camera.main;

		Vector3 rightPosition = mainCamera.transform.position;
		Vector3 leftPosition = mainCamera.transform.position;
		Vector3 upPosition = mainCamera.transform.position;
		Vector3 downPosition = mainCamera.transform.position;

		rightPosition.x = rightPosition.x + mainCamera.orthographicSize * 2 * mainCamera.aspect;
		leftPosition.x = leftPosition.x - mainCamera.orthographicSize * 2 * mainCamera.aspect;
		upPosition.y = upPosition.y + mainCamera.orthographicSize * 2;
		downPosition.y = downPosition.y - mainCamera.orthographicSize * 2;

		if (rightCamera != null) {
			rightCamera.transform.position = rightPosition;
		}

		if (leftCamera != null) {
			leftCamera.transform.position = leftPosition;
		}

		if (upCamera != null) {
			upCamera.transform.position = upPosition;
		}

		if (downCamera != null) {
			downCamera.transform.position = downPosition;
		}
			


	}
}
