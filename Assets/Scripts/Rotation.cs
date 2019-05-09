using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour
{
	[SerializeField] private float angle = 1.0f;
	[SerializeField] private float slowness = 1.0f;
	[SerializeField] private float delay = 1.0f;
	[SerializeField] private int turns = 1_000_000;

	[SerializeField] private bool doesLoop = false;
	[SerializeField] private bool clockwise = true;
	
	
	// Use this for initialization
	void Start()
	{
		StartCoroutine(RotateObject(angle, Vector3.up, slowness,this.delay, turns, this.doesLoop, this.clockwise));
	}

	public IEnumerator RotateObject(float angle, Vector3 axis, float inTime,float delay, int turns, bool doesLoop, bool clockwise)
	{

		// calculate rotation speed
		float rotationSpeed = angle / inTime;

		
		while (turns > 0)
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
			if(doesLoop)
			{
				while(deltaAngle > 0)
				{
					deltaAngle -= rotationSpeed * Time.deltaTime;
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
				}//while
			}//if(doesloop)

			// delay here
			yield return new WaitForSeconds(delay);

			--turns;
		}//main while loop
	}
}
