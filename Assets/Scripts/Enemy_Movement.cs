using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
	This script allows the enemy to move and rotate
		in inspector select if move=true or rotate=true
	 
*/
public class Enemy_Movement : MonoBehaviour
{
	[SerializeField]
	private bool movement;
	[SerializeField]
	private bool rotation;
}
