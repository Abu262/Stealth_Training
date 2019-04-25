 
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class FieldOfVisionSetup : MonoBehaviour {

	public float fieldViewAngle; // in degrees \/
	public float fieldDepth; //radius of the collider
	public int raysInCast; //appearance of fieldView
	public float enemyEyeHeight;

	private EnemySight enemySight;
	private FieldOfVision fieldOfVision;
	
	void Start() {
		enemySight = GetComponentInChildren<EnemySight>();
		fieldOfVision = GetComponentInChildren<FieldOfVision>();
		
		//set angle
		enemySight.setConeSize(fieldViewAngle/2); //degrees
		fieldOfVision.setAngle(fieldViewAngle*Mathf.Deg2Rad/2); //in radians
		
		//set radius
		enemySight.setColliderRadius(fieldDepth);
		fieldOfVision.setSightRange(fieldDepth);
		
		//set the raycast height
		enemySight.setRaycastHeight(enemyEyeHeight);
		
		//set number of rays in the raycast
		fieldOfVision.setRaysToCast(raysInCast);
		
	}
	
	void Update() {
		
	}

}
 
 