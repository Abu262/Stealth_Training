using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySight : MonoBehaviour
{
	[SerializeField] private float m_halfConeSize = 45f;
	
	
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
		/*if(other.gameObject == Player) {
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
		}*/
		
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
		bool isInFront = sqrAngle < m_halfConeSize;
		if (other.gameObject.name == "Player") {
			print(sqrAngle + " " + other.gameObject.name);
		}
		
		Debug.DrawLine(myPos, theirPos, isInFront ? Color.green : Color.red);
		
		if (isInFront) {
			int mask = 1 << LayerMask.NameToLayer("Env");
			if (!Physics.Linecast(myPos, theirPos, mask)) {
				print("sensing something " + other.gameObject.name);
			}
		}
	}
}
