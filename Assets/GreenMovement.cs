using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class GreenMovement : MonoBehaviour
{
    public Transform[] points;
    private int destPoint = 0;
    public GameObject player;
    public GameObject[] LoudFloor;
    PlayerColliding[] PC;
    private NavMeshAgent agent;
    //public GameObject waypoint;
    // Start is called before the first frame update
    void Start()
    {
        PC = new PlayerColliding[LoudFloor.Length];
        agent = GetComponent<NavMeshAgent>();

		for(int i=0; i<LoudFloor.Length; i++)
		{Debug.Log(i);
			PC[i] = LoudFloor[i].GetComponent<PlayerColliding>();
		}
        //PC = LoudFloor.GetComponent <PlayerColliding>();
        GotoNextPoint();
    }

    // Update is called once per frame
    void Update()
    {
		for(int i=0;i<PC.Length;i++)
		{
         
			if (PC[i].PlayerTouching == true)
			{
				Debug.Log("walking");
				agent.destination = player.transform.position;
			}
			else
			{
				if (!agent.pathPending && agent.remainingDistance < 0.5f)
					GotoNextPoint();
			}
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
}
