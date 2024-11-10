using UnityEngine;
using System.Collections;
using UnityEngine.Events;

[RequireComponent(typeof(Rigidbody))]
public class Controller : MonoBehaviour 
{
	Rigidbody rigidbody;
	
	private bool isMoving;
	private bool IsMoving
	{
		get => isMoving;
		set
		{
			isMoving = value;
			MovingStateChanged?.Invoke(isMoving);
		}
	}
	
	[SerializeField] private float moveSpeed = 6, rotateSpeed;

	public DynamicJoystick variableJoystick;
	
	[SerializeField] private UnityEvent<bool> MovingStateChanged;

	void Start () 
	{
		rigidbody = GetComponent<Rigidbody> ();
	}

	void FixedUpdate() {
		Vector3 direction = Vector3.forward * variableJoystick.Vertical + Vector3.right * variableJoystick.Horizontal;
		MoveTowardTarget(direction);
		RotateTowardsTargetOnYAxis(direction);
	}

	void MoveTowardTarget(Vector3 direction)
	{
		if (direction.sqrMagnitude > 0.1f)
		{
			rigidbody.MovePosition (rigidbody.position + direction * (moveSpeed * Time.fixedDeltaTime));

			if (!IsMoving)
			{
				IsMoving = true;
			}
		}
		else
		{
			if (IsMoving)
			{
				IsMoving = false;
			}
		}
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