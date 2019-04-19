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
	private bool pause_bool;

	[SerializeField] private float pause;

	[SerializeField] private float speed;
	[SerializeField] private float angle;

	//private float init_angle;
	//private float final_angle;
	private float delta_angle;
	[SerializeField] float targetAngle;
	[SerializeField] float timer;

	void Awake()
	{
		//initially angle is 0 and it will count upwards
		delta_angle = angle;
		timer = pause;
		pause_bool = false;
		//time = Time.time;
	}

	void Update()
	{
		//testing the code below
		//Debug.Log(angle -= Time.deltaTime * speed);
		


		if(movement)
		{
			//code for movement goes here
		}
		else if(rotation)
		{
			targetAngle = transform.eulerAngles.y + angle;
			if (targetAngle > 180)
			{
				targetAngle -= 360;
			}
			//if > 180, subtract by 360;
			StartCoroutine("RotationCoroutine");
			rotation = false;
		}
		else
		{
			if(transform.eulerAngles.y == targetAngle && !pause_bool)
			{
				pause_bool = true;
				timer = pause;
			}
			if (pause_bool)
			{
				timer -= Time.deltaTime;
				if (timer < 0)
				{
					rotation = true;
					pause_bool = false;
				}

			}
		}
	}
	void Rotation()
	{
		if(!clockwise)
		{
			transform.Rotate(0f, speed * Time.deltaTime, 0f);
		}

	}

	IEnumerator RotationCoroutine()
	{   //float tar = 0 + 90 first loop
		Vector3 _startAngle = transform.eulerAngles;
		Vector3 _targetAngle = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y + angle, transform.eulerAngles.z); //gets the current angle in y-axis + angle desired
		Vector3 currentAngle = _startAngle;
		while (currentAngle != _targetAngle)
		{
			this.transform.Rotate(0, speed * Time.deltaTime, 0);
			if (this.transform.eulerAngles.y >= _targetAngle.y)
			{
				this.transform.eulerAngles = _targetAngle;
				currentAngle = _targetAngle;
			}

			yield return null;
			//yield return new WaitForSeconds(pause);
		}
	}

	void Rotation( float pause = 0, float speed = 4.20f, float _angle = 0f)
	{
		if (!clockwise)
		{
			//if(transform.rotation.eulerAngles.y < _angle)
			

			if (transform.rotation.eulerAngles.y % _angle == 0f && !pause_bool)
			{
				pause_bool = true;
				timer = pause;
			}
			if (pause_bool)
			{
				timer -= Time.deltaTime;
				if (timer < 0)
				{
					print(timer);
					pause_bool = false;
					transform.Rotate(0f, speed * Time.deltaTime, 0f);
				}

			}
			else
				transform.Rotate(0f, speed * Time.deltaTime, 0f);
			


			//else


			//StartCoroutine(PauseRotation());

		}

		//else		
			//transform.Rotate(0, Time.deltaTime * speed * -1, 0);
	}
	IEnumerator PauseRotation()
	{
		print("inside coroutine");
		yield return new WaitForSeconds(pause);
	}
}
//Garbage code that I might want to use later
//transform.Rotate(Vector3.up * Time.deltaTime * speed, _angle, Space.World);
//transform.Rotate(Vector3.up* Time.deltaTime* speed * -1, _angle, Space.World);
//transform.Rotate(0, Time.deltaTime * speed, 0);



//transform.Rotate(0, Time.deltaTime * speed, 0);//x , y , z
//if(transform.position == Vector3.up * )


//Quaternion desiredRotation = Quaternion.Euler(0, angle, 0);
//transform.Rotate(Vector3.up, _angle);
			//transform.rotation = Quaternion.Lerp(transform.rotation, desiredRotation, speed * Time.deltaTime);
			//if(delta_angle >= 0)
			//{
			//	delta_angle -= Time.deltaTime;
			//}
