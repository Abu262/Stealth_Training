using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySight : MonoBehaviour
{
	
	public float FieldOfViewAngle = 110f;
	public bool PlayerInSight;
	public float AdjustRaycastHeight = 1f;
	//public Vector3 PlayerLastSighting;
	
	private GameObject Player;
	private SphereCollider col;
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindGameObjectsWithTag("Player")[0];
		col = GetComponent<SphereCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
	
	void OnTriggerStay(Collider other) {
		Debug.Log("collision");
		if(other.gameObject == Player) {
			PlayerInSight = false;
			Debug.Log("Player");
			Vector3 direction = other.transform.position - transform.position;
			float angle = Vector3.Angle(direction, transform.forward);
			
			if (angle < FieldOfViewAngle * 0.5f) {
				RaycastHit hit;
				if (Physics.Raycast(transform.position + (transform.up*AdjustRaycastHeight), direction.normalized, out hit, col.radius)) {
					if (hit.collider.gameObject == Player) {
						PlayerInSight = true;
						Debug.Log("Player in view");
					}
				}
			}
		}
	}
}
