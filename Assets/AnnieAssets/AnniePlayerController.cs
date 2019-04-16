using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnniePlayerController : MonoBehaviour
{
    public float speed;

    private Rigidbody rb;

    void Start ()
    {
        rb = GetComponent<Rigidbody>();
		rb.freezeRotation = true;
    }

    void FixedUpdate ()
    {
	if (Input.GetKey(KeyCode.RightArrow)) {
		rb.velocity = transform.right * speed;
	}
	
	if (Input.GetKey(KeyCode.LeftArrow)) {
		rb.velocity = -transform.right * speed;
	}
	
	if (Input.GetKey(KeyCode.UpArrow)) {
		rb.velocity = new Vector3(0, 0, 1) * speed;
	}
	
	if (Input.GetKey(KeyCode.DownArrow)) {
		rb.velocity = new Vector3(0, 0, -1) * speed;
	}
		
        /*float moveHorizontal = Input.GetAxis ("Horizontal");
        float moveVertical = Input.GetAxis ("Vertical");

        Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);

        rb.AddForce (movement * speed);*/
    }
}
