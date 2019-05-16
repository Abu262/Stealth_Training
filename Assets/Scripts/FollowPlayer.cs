using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class FollowPlayer : MonoBehaviour
{
    public Transform[] points;
    private int destPoint = 0;
    private GameObject Player;
    private NavMeshAgent agent;
	private bool chasing = true;
	
    // Start is called before the first frame update
    void Start()
    {
		Player = GameObject.FindWithTag("Player");
        agent = GetComponent<NavMeshAgent>();
        //GotoNextPoint();
    }

    // Update is called once per frame
    void Update()
    {
		if (chasing) {
			agent.destination = Player.transform.position;
		}
        
    }

    void GotoNextPoint()
    {
        // Returns if no points have been set up
        if (points.Length == 0)
            return;

        // Set the agent to go to the currently selected destination.
        agent.destination = points[destPoint].position;

        // Choose the next point in the array as the destination,
        // cycling to the start if necessary.
        destPoint = (destPoint + 1) % points.Length;
    }
	
	public void AgentMovement(float newSpeed, float newRotation, float newAccel) {
		agent.speed = newSpeed;
		agent.angularSpeed = newRotation;
		agent.acceleration = newAccel;
	}
	
	public void StopChasing() {
		chasing = false;
		agent.enabled = false;
		//agent.ResetPath();
		//agent.Stop();
	}
	
	public void StartChasing() {
		chasing = true;
		agent.enabled = true;
		agent.destination = Player.transform.position;
	}
}
