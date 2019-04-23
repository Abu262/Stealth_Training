using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour
{
	[SerializeField] private float angle = 1.0f;
	[SerializeField] private float slowness = 1.0f;
	[SerializeField] private float delay = 1.0f;

	[SerializeField] private bool clockwise = true;
	// Use this for initialization
	void Start()
	{
		StartCoroutine(RotateObject(angle, Vector3.up, slowness));
	}

	IEnumerator RotateObject(float angle, Vector3 axis, float inTime)
	{
		// calculate rotation speed
		float rotationSpeed = angle / inTime;

		
		while (true)
		{
			// save starting rotation position
			Quaternion startRotation = transform.rotation;

			float deltaAngle = 0;

			// rotate until reaching angle
			while (deltaAngle < angle)
			{
				deltaAngle += rotationSpeed * Time.deltaTime;
				deltaAngle = Mathf.Min(deltaAngle, angle);

				if (clockwise)
				{
					transform.rotation = startRotation * Quaternion.AngleAxis(deltaAngle, axis);
				}
				else
				{
					transform.rotation = startRotation * Quaternion.AngleAxis(-deltaAngle, axis);
				}
					

				yield return null;
			}

			// delay here
			yield return new WaitForSeconds(delay);
		}
	}
}
