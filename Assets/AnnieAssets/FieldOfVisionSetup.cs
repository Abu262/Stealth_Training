 
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class FieldOfVisionSetup : MonoBehaviour {

	public float fieldViewAngle = 60f; // in degrees \/
	public float fieldDepth = 10f; //radius of the collider
	public int raysInCast = 100; //appearance of fieldView
	public float enemyEyeHeight = 1f;
	public GameObject enemyFront;

	private EnemySight enemySight;
	private FieldOfVision fieldOfVision;
	
	void Start() {
		enemySight = GetComponentInChildren<EnemySight>();
		fieldOfVision = GetComponentInChildren<FieldOfVision>();
		
		//set angle
		enemySight.setConeSize(fieldViewAngle/2); //degrees
		fieldOfVision.setAngle(fieldViewAngle*Mathf.Deg2Rad/2); //in radians
		
		//set radius - need to adjust for weird scaling
		Debug.Log(enemyFront.transform.localScale.x);
		enemySight.setColliderRadius(fieldDepth);
		fieldOfVision.setSightRange(fieldDepth/(1/enemyFront.transform.localScale.x));
		
		
		//set the raycast height
		enemySight.setRaycastHeight(enemyEyeHeight);
		
		//set number of rays in the raycast
		fieldOfVision.setRaysToCast(raysInCast);
		
	}
	
	void Update() {
		
	}

}
 
 