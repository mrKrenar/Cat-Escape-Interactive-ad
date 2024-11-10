using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody))]
public class Controller : MonoBehaviour {

	public DynamicJoystick variableJoystick;
	
	public float moveSpeed = 6, rotateSpeed;

	Rigidbody rigidbody;
	
	void Start () {
		rigidbody = GetComponent<Rigidbody> ();
	}

	void FixedUpdate() {
		Vector3 direction = Vector3.forward * variableJoystick.Vertical + Vector3.right * variableJoystick.Horizontal;
		rigidbody.MovePosition (rigidbody.position + direction * (moveSpeed * Time.fixedDeltaTime));
		RotateTowardsTargetOnYAxis(direction);
	}

	void RotateTowardsTargetOnYAxis(Vector3 targetPosition)
	{
		Vector3 directionToTarget = targetPosition;

		directionToTarget.y = 0;

		// If the direction is not zero, perform the rotation
		if (directionToTarget.sqrMagnitude > 0.1f)
		{
			// Calculate the target rotation (only on the Y-axis)
			Quaternion targetRotation = Quaternion.LookRotation(directionToTarget);

			// Interpolate between current rotation and target rotation on the Y-axis only
			Quaternion smoothRotation = Quaternion.RotateTowards(
				rigidbody.rotation, 
				targetRotation, 
				rotateSpeed * Time.fixedDeltaTime
			);

			// Apply the rotation
			rigidbody.MoveRotation(smoothRotation);
		}
	}
}