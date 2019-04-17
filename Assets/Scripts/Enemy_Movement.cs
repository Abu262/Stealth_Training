using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
	This script allows the enemy to move and rotate
		- in inspector select if move you want to move or rotate object

		-movement:
			?

		- rotate:
			-stops are the number of stops the enemy makes when rotating
			-change-in-time is the amount of time stopped before continuing
			  to the next stop (in seconds)
	 
*/
public class Enemy_Movement : MonoBehaviour
{
	[SerializeField] private bool movement; //boolean flag that determine if
	[SerializeField] private bool rotation; // a function is called
	[SerializeField] private bool clockwise;

	[SerializeField] private int pause;

	[SerializeField] private float speed;
	[SerializeField] private float angle;

	void Update()
	{
		if(movement)
		{
			//code for movement goes here
		}
		else if(rotation)
		{
			Rotation(pause, speed, angle);
		}
	}

	void Rotation(int pause = 0, float speed = 4.20f, float _angle = 0f)
	{
		if (!clockwise)
		{
			transform.Rotate(0, Time.deltaTime * speed, 0);//x , y , z
			if(transform.position == Vector3.up * )
			StartCoroutine(PauseRotation());
		}
			
		else		
			transform.Rotate(0, Time.deltaTime * speed * -1, 0);
	}
	IEnumerator PauseRotation()
	{
		yield return new WaitForSeconds(pause);
	}
}
//Garbage code that I might want to use later
//transform.Rotate(Vector3.up * Time.deltaTime * speed, _angle, Space.World);
//transform.Rotate(Vector3.up* Time.deltaTime* speed * -1, _angle, Space.World);