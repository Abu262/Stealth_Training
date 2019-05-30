using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float x = -26f;
    public float y = 25f;
    public float z = -33f;
    private Rigidbody rb;
    public Transform camPivot;
    float heading = 0;
    public Transform cam;
    public float speed = 10f;

    private Vector3 offset; //c
    public float turnSpeed = 2.0f; //c
    Vector2 input;
    Transform camTransform;
    Transform playerTransform;
	
	public float maxSprintSpeed = 20.0f;
	//public float accel = 1.0f;
	//sneak at a slow speed
	public float sneakSpeed = 3.0f;
    bool topdown = false;
    void Awake()
    {
        camTransform = cam.GetComponent<Transform>();
        playerTransform = GetComponent<Transform>();
    }  


    void Start()
    {
        rb = GetComponent<Rigidbody>();
        offset = new Vector3(playerTransform.position.x + x, playerTransform.position.y + y, playerTransform.position.z + z); //c

    }

    void Update()//FixedUpdate
    {
        if(Input.GetKey(KeyCode.Q) || Input.GetKey(","))
        {
   //         camTransform.position = new Vector3(camTransform.position.x + 1, camTransform.position.y, camTransform.position.z);
                //.Rotate(new Vector3(camTransform.eulerAngles.x, camTransform.eulerAngles.y + 0.5f, camTransform.eulerAngles.z));
            offset = Quaternion.AngleAxis(-0.5f * turnSpeed, Vector3.up) * offset; //c
        }
        if(Input.GetKey(KeyCode.E) || Input.GetKey("."))
        {

 //           camTransform.position = new Vector3(camTransform.position.x - 1, camTransform.position.y, camTransform.position.z);
            //camTransform.Rotate(new Vector3(camTransform.eulerAngles.x, camTransform.eulerAngles.y - 0.5f, camTransform.eulerAngles.z));
            offset = Quaternion.AngleAxis(0.5f * turnSpeed, Vector3.up) * offset; //c
        }

        if(Input.GetKeyUp(KeyCode.R))
        {
            topdown = !topdown;
        }
        if(topdown)
        {
            if (offset.y < playerTransform.position.y + y + 30)
            {
                offset.y += 1f;
            }
            if (offset.y > playerTransform.position.y + y + 30)
            {
                offset.y = playerTransform.position.y + y + 30;
            }
            //           offset.y = playerTransform.position.y + y  + 120;// = new Vector3(offset.x, offset.y  +  5, offset.z);
        }
        else
        {
            if (offset.y > playerTransform.position.y + y)
            {

                offset.y -= 1f;
            }
            if  (offset.y < playerTransform.position.y + y)
            {
                offset.y = playerTransform.position.y + y;
            }
        }
        
        /*MOVE VIA MOUSE*/
        //heading += Input.GetAxis("Mouse X") * Time.deltaTime*45;
        //camPivot.rotation = Quaternion.Euler(0, heading, 0);

        input = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        input = Vector2.ClampMagnitude(input, 1);
        
        Vector3 camF = cam.forward;
        Vector3 camR = cam.right;
        camF.y = 0;
        camR.y = 0;
        camF = camF.normalized;
        camR = camR.normalized;
		if (Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.RightControl)) {
            snek(camF, camR);
		} else {
            walk(camF, camR);

        }
//		camTransform.position = new Vector3(playerTransform.position.x + x,playerTransform.position.y + y,playerTransform.position.z +z); //c
        //offset = Quaternion.AngleAxis(Input.GetAxis("Mouse X") * turnSpeed, Vector3.up) * offset;
        camTransform.position = transform.position + offset;
        camTransform.LookAt(transform.position);
        //camTransform.LookAt(playerTransform.position);//c
       // camTransform.eulerAngles = new Vector3(60,
//0,
//0
//);
        //transform.position += (camF * input.y + camR * input.x) * Time.deltaTime * 5;
        // cam.position = (Quaternion.Euler(30, 45, 0) * Vector3.forward);

        //if (transform.position.y < -1)
        //print("Game Over");

        //if (rb.velocity.y < -0.1)
        //    print("Game Over");
    }

    void FixedUpdate()
    {
        
    }

    void sprint(Vector3 camF, Vector3 camR)
    {

//        rb.MovePosition(playerTransform.position + (camF * input.y + camR * input.x) * Time.deltaTime * maxSprintSpeed);
    }
    void walk(Vector3 camF, Vector3 camR)
    {
        rb.MovePosition(playerTransform.position + (camF * input.y + camR * input.x) * Time.deltaTime * speed);// 5);
    }
    void snek(Vector3 camF, Vector3 camR)
    {
        rb.MovePosition(playerTransform.position + (camF * input.y + camR * input.x) * Time.deltaTime * sneakSpeed);
    }
}
