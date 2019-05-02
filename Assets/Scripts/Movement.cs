using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private Rigidbody rb;
    public Transform camPivot;
    float heading = 0;
    public Transform cam;

    Vector2 input;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()//FixedUpdate
    {
        if(Input.GetKey(KeyCode.Q))
        {
            heading++;
            camPivot.rotation = Quaternion.Euler(0, heading+1, 0);
        }
        if(Input.GetKey(KeyCode.E))
        {
            heading--;
            camPivot.rotation = Quaternion.Euler(0, heading+1, 0);
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
        //transform.position += (camF * input.y + camR * input.x) * Time.deltaTime * 5;
       // cam.position = (Quaternion.Euler(30, 45, 0) * Vector3.forward);

        //if (transform.position.y < -1)
            //print("Game Over");

        //if (rb.velocity.y < -0.1)
        //    print("Game Over");
    }
}
