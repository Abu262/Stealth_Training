using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger_Rotation : MonoBehaviour
{
	[SerializeField] private float angle = 1.0f;
	[SerializeField] private float slowness = 1.0f;
	[SerializeField] private float delay = 1.0f;
	[SerializeField] private int turns = 1_000_000;

	[SerializeField] private bool doesLoop = false;
	[SerializeField] private bool clockwise = true;

	public Rotation target_obj = null;

	void OnTriggerEnter(Collider other)
	{
		print("OnTriggerEnter");
		if (target_obj != null)
		{
			print("!null");
			target_obj.StartCoroutine("RotateObj");
			StartCoroutine(target_obj.RotateObject(angle, Vector3.up, slowness, turns));

		}
	}
}
