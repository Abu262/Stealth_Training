using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PressureEvent : MonoBehaviour
{
	
	public List<GameObject> wallEnemies = new List<GameObject>();
	private List<GameObject> transformedEnemies = new List<GameObject>();
	public GameObject enemyToSpawn;
	
	public Material inactiveMaterial;
	public Material activeMaterial;
	//private Material mat;
	
	private bool enemiesConverted = false;
	private bool enemiesMoving = false;
	
	//private List<GameObject> colliderList = new List<GameObject>();
	
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        //wallEnemies[0];
    }
	
	public void OnTriggerEnter(Collider other) {
		if(other.tag == "Player") {
			Debug.Log("ENTER");
			GetComponent<Renderer>().material = activeMaterial;
			if(!enemiesConverted) {
				for(int i = 0; i < wallEnemies.Count; i++) {
					var pos = wallEnemies[i].transform.position;
					var rot = wallEnemies[i].transform.rotation;
					wallEnemies[i].SetActive(false);
					GameObject newEnemy = Instantiate(enemyToSpawn, pos, rot) as GameObject;
					newEnemy.GetComponent<NavMeshAgent>().Warp(pos);
					transformedEnemies.Add(newEnemy);
					newEnemy.SetActive(true);
				}
			}
			
			if(enemiesConverted && !enemiesMoving) {
				for(int i = 0; i < wallEnemies.Count; i++) {
					//transformedEnemies[i].GetComponent<FollowPlayer>().enabled = true;
					transformedEnemies[i].GetComponent<FollowPlayer>().StartChasing();					
				}
			}
			enemiesConverted = true;	
			enemiesMoving = true;
		}	
	}
	
	public void OnTriggerStay(Collider other) {
		if(other.tag == "Player") {
			Debug.Log("STAY");	
		}
	}
	
	public void OnTriggerExit(Collider other) {
		Debug.Log(other);
		if(other.tag == "Player") {
			Debug.Log("EXIT");
			GetComponent<Renderer>().material = inactiveMaterial;	
			if(enemiesConverted && enemiesMoving) {
				for(int i = 0; i < transformedEnemies.Count; i++) {
					Debug.Log(i);
					transformedEnemies[i].GetComponent<FollowPlayer>().StopChasing();
					//transformedEnemies[i].GetComponent<FollowPlayer>().enabled = false;					
				}
				enemiesMoving = false;
			}
			
		}
		
	}
}
