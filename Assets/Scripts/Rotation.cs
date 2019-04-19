using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour
{
	[SerializeField] private float angle;
	//private float timer = 5f;
	//private float reset;
	//private bool pause = false; 
	


    void Awake()
	{
		//reset = timer;
		
		
	}

	// Start is called before the first frame update
    void Start()
    {
		
    }

    // Update is called once per frame
    void Update()
    {
		Vector3 initialState = this.transform.eulerAngles;
		Vector3 targetState = new Vector3(initialState.x, initialState.y + angle, initialState.z);
		//transform.rotation; 
		Vector3 currentState = Vector3.Lerp(initialState, targetState, 0.05f);	
		
    }
	void Rotate()
	{
		//pause = true;
		//timer = reset;
		transform.Rotate(Vector3.up);
	}
}

/*
 
	 print(timer);
		timer -= Time.deltaTime;

		if (timer > 0 && !pause)
			Rotate();
		else
		{
			pause = true;
			timer = reset;
		}
	 
	 */
