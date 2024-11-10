using UnityEngine;
using System.Collections;

public class Controller : MonoBehaviour {

	public DynamicJoystick variableJoystick;
	
	public float moveSpeed = 6;

	Rigidbody rigidbody;
	Camera viewCamera;
	// Vector3 velocity;

	void Start () {
		rigidbody = GetComponent<Rigidbody> ();
		viewCamera = Camera.main;
	}

	// void Update () {
	// 	Vector3 mousePos = viewCamera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, viewCamera.transform.position.y));
	// 	//transform.LookAt (mousePos + Vector3.up * transform.position.y);
	// 	// velocity = new Vector3 (Input.GetAxisRaw ("Horizontal"), 0, Input.GetAxisRaw ("Vertical")).normalized * moveSpeed;
	// 	
	// 	
	// 	
	// 	
	// 	
	// 	// Calculate direction to the target
	// 	Vector3 direction = mousePos /*+ Vector3.up * transform.position.y*/ - transform.position;
	//
	// 	// Set the X and Z components to zero to prevent any change in rotation on those axes
	// 	direction.z = 0;
	// 	direction.x = 0;
	//
	// 	// If the direction has a non-zero length, calculate the rotation
	// 	// if (direction.magnitude > 0.1f)
	// 	// {
	// 		// Create a rotation that points to the target, but only for the Y axis
	// 		Quaternion targetRotation = Quaternion.LookRotation(direction);
	//
	// 		// Set the X and Z components of the rotation to 0, keeping only the Y rotation
	// 		targetRotation = Quaternion.Euler(0f, targetRotation.eulerAngles.y, 0f);
	//
	// 		// Instantly set the rotation of the GameObject to the calculated target rotation
	// 		transform.rotation = targetRotation;
	// 	// }
	// }

	void FixedUpdate() {
		Vector3 direction = Vector3.forward * variableJoystick.Vertical + Vector3.right * variableJoystick.Horizontal;
		rigidbody.MovePosition (rigidbody.position + direction * (moveSpeed * Time.fixedDeltaTime));
	}
}