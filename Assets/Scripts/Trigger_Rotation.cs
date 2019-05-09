using System;
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

	//public Rotation target_obj = null;
	public GameObject target = null;
	private Rotation target_script;
	void Awake()
	{
		if(target != null)
		{
			target_script = target.GetComponent<Rotation>();
		}
	}

	void OnTriggerEnter(Collider other)
	{
		
		//print("OnTriggerEnter");
		if (target != null)
		{
			//print("!null");
			StartCoroutine(target_script.RotateObject(angle, Vector3.up, slowness,delay, turns, doesLoop,clockwise));
			//print("outside");
		}
	}


}