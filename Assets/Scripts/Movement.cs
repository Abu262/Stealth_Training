using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private Rigidbody rb;
    public Transform camPivot;
    float heading = 0;
    public Transform cam;
    private Vector3 offset; //c
    public float turnSpeed = 4.0f; //c
    Vector2 input;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        offset = new Vector3(transform.position.x - 26.0f, transform.position.y + 25.0f, transform.position.z - 33.0f); //c
    }

    void Update()//FixedUpdate
    {
        if(Input.GetKey(KeyCode.Q))
        {
            offset = Quaternion.AngleAxis(-0.5f * turnSpeed, Vector3.up) * offset; //c
        }
        if(Input.GetKey(KeyCode.E))
        {
            offset = Quaternion.AngleAxis(0.5f * turnSpeed, Vector3.up) * offset; //c
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
        rb.MovePosition(transform.position + (camF * input.y + camR * input.x) * Time.deltaTime * 5);
        cam.transform.position = transform.position + offset; //c
        cam.transform.LookAt(transform.position);//c
        //transform.position += (camF * input.y + camR * input.x) * Time.deltaTime * 5;
        // cam.position = (Quaternion.Euler(30, 45, 0) * Vector3.forward);

        //if (transform.position.y < -1)
        //print("Game Over");

        //if (rb.velocity.y < -0.1)
        //    print("Game Over");
    }


}
