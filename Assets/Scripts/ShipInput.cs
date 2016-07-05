using UnityEngine;
using System.Collections;

public class ShipInput : MonoBehaviour {

	ShipMovements shipMovements;
	ShipProjectileSpawner projectile;

	public float timeBetweenDownUp = 0.3f;
	float touchStartTime = 0.0f;


	void OnEnable(){
		// Take components
		shipMovements = GetComponent<ShipMovements>();
		projectile = GetComponent<ShipProjectileSpawner> ();

		// Subscribe to events 
		EasyTouch.On_TouchDown += OnTouchDown;
		EasyTouch.On_SimpleTap += OnSimpleTouch;
		EasyTouch.On_TouchUp += OnTouchUp;
		EasyTouch.On_TouchStart += OnTouchStart;
	}

	void OnDisable(){
		EasyTouch.On_TouchDown -= OnTouchDown;
		EasyTouch.On_SimpleTap -= OnSimpleTouch;
		EasyTouch.On_TouchUp -= OnTouchUp;
	}

	void OnDestroy(){
		EasyTouch.On_TouchDown -= OnTouchDown;
		EasyTouch.On_SimpleTap -= OnSimpleTouch;
		EasyTouch.On_TouchUp -= OnTouchUp;
	}

	public void OnTouchDown(Gesture gesture)
	{
		if (shipMovements != null)
			shipMovements.TryReachPosition (gesture.position);
	}

	public void OnTouchUp(Gesture gesture)
	{
		if (shipMovements != null)
			shipMovements.DontReachPosition ();

		if (projectile != null) {
			bool canShoot = ((Time.time - touchStartTime) < timeBetweenDownUp);
			if (canShoot)
				projectile.Shoot ();
		}
	}

	public void OnSimpleTouch(Gesture gesture)
	{
//		if (projectile != null)
//			projectile.Shoot ();
	}

	public void OnTouchStart(Gesture gesture)
	{
		touchStartTime = Time.time;
	}
}
