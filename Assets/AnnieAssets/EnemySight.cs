﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySight : MonoBehaviour
{
	public float HalfConeSize = 75f;	
	public float FieldOfViewAngle = 110f;
	public float AdjustRaycastHeight = 1f;
	public float SphereRadius = 10f;
	public SphereCollider col;
	private GameObject Player;
	public bool PlayerInSight;

	
	private float actualAngle;
	
    void Start()
    {
        Player = GameObject.FindGameObjectsWithTag("Player")[0];
		col = GetComponent<SphereCollider>();
		SphereRadius = col.radius;
		


    }

    // Update is called once per frame
    void Update()
    {
        //adjust SphereCollider with SphereRadius
		col.radius = SphereRadius;
    }
	

	
	void OnTriggerStay(Collider other) {
		
		Vector3 myPos = transform.position;
		Vector3 myVector = transform.forward;
		Vector3 theirPos = other.transform.position;
		Vector3 theirVector = theirPos - myPos;
		
		float mag = Vector3.SqrMagnitude(myVector) * Vector3.SqrMagnitude(theirVector);
		
		if (mag == 0f) {
			return;
		}
		
		float dotProd = Vector3.Dot(myVector, theirPos - myPos);
		bool isNegative = dotProd < 0f;
		dotProd = dotProd * dotProd;
		if(isNegative) {
			dotProd *= -1;
		}
		
		float sqrAngle = Mathf.Rad2Deg * Mathf.Acos(dotProd/mag);
		bool isInFront = sqrAngle < HalfConeSize;
		if (other.gameObject.name == "Player") {
			print(sqrAngle + " " + other.gameObject.name);
		}
		
		Debug.DrawLine(myPos, theirPos, isInFront ? Color.green : Color.red);
		
	}
	

	public void setColliderRadius(float newRadius) {
		SphereRadius = newRadius;
	}
	
	public void setConeSize(float newConeSize) {
		HalfConeSize = newConeSize;
	}
	
	public void setFieldOfViewAngle(float newAngle) {
		FieldOfViewAngle = newAngle;
	}
	
	public void setRaycastHeight(float newHeight) {
		AdjustRaycastHeight = newHeight;
	}
}
