﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkToWayPoints : MonoBehaviour
{
    // put the points from unity interface
    public Transform[] wayPointList;

    public int currentWayPoint = 0;
    Transform targetWayPoint;

    public float speed = 4f;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // check if we have somewere to walk
        if (currentWayPoint < this.wayPointList.Length)
        {
            if (targetWayPoint == null)
                targetWayPoint = wayPointList[currentWayPoint];
            walk();
        }
    }

    void walk()
    {
        // rotate towards the target
        transform.forward = Vector3.RotateTowards(transform.forward, targetWayPoint.position - transform.position, speed * Time.deltaTime, 0.0f);
        //transform.LookAt(targetWayPoint.position, transform.up);
        //transform.LookAt(2 * transform.position - targetWayPoint.position);
        //Vector3 relativePos = targetWayPoint.position - transform.position;
        //transform.rotation = Quaternion.LookRotation(relativePos);
        // move towards the target
        transform.position = Vector3.MoveTowards(transform.position, targetWayPoint.position, speed * Time.deltaTime);

        if (transform.position.x == targetWayPoint.position.x)
        {
            currentWayPoint++;
            if (currentWayPoint == this.wayPointList.Length)
            {
                targetWayPoint = wayPointList[0];
                currentWayPoint = 0;
            }
            else
            {
                targetWayPoint = wayPointList[currentWayPoint];
            }
        }
    }
}

