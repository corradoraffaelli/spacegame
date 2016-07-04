using UnityEngine;
using System.Collections;

public class ShipInput : MonoBehaviour {

	ShipMovements shipMovements;
	ShipProjectile projectile;


	void OnEnable(){
		// Take components
		shipMovements = GetComponent<ShipMovements>();
		projectile = GetComponent<ShipProjectile> ();

		// Subscribe to events 
		EasyTouch.On_TouchDown += OnTouchDown;
		EasyTouch.On_SimpleTap += OnSimpleTouch;
		EasyTouch.On_TouchUp += OnTouchUp;
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
	}

	public void OnSimpleTouch(Gesture gesture)
	{
		if (projectile != null)
			projectile.Shoot ();
	}
}
