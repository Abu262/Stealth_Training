using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    //private Rigidbody rb;
    public Transform camPivot;
    float heading = 0;
    public Transform cam;

    Vector2 input;

    void Start()
    {
        //rb = GetComponent<Rigidbody>();
    }

    void Update()//FixedUpdate
    {
        heading += Input.GetAxis("Mouse X") * Time.deltaTime*45;
        camPivot.rotation = Quaternion.Euler(0, heading, 0);

        input = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        input = Vector2.ClampMagnitude(input, 1);

        ///transform.position += new Vector3(input.x, 0, input.y) * Time.deltaTime * 5;
        Vector3 camF = cam.forward;
        Vector3 camR = cam.right;

        camF.y = 0;
        camR.y = 0;
        camF = camF.normalized;
        camR = camR.normalized;

        transform.position += (camF * input.y + camR * input.x) * Time.deltaTime * 5;

        /*float moveHorizontal = Input.GetAxis("Horizontal") * 20;
        float moveVertical = Input.GetAxis("Vertical") * 20;

        Vector3 movement = new Vector3(moveHorizontal, 0.0f,moveVertical);

        rb.AddForce(movement);*/
    }
}
