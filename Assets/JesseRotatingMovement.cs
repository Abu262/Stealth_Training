using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingMovement : MonoBehaviour
{
    public float RotateAngle;
    public float RotateTime;
    public float rotationSpeed;

     // Use this for initialization
     void Start()
    {
        StartCoroutine(RotateObject(RotateAngle, Vector3.down, RotateTime));
    }

    IEnumerator RotateObject(float angle, Vector3 axis, float inTime)
    {
        // calculate rotation speed
        //float rotationSpeed = angle / inTime;

        while (true)
        {
            // save starting rotation position
            Quaternion startRotation = transform.rotation;

            float deltaAngle = 0;

            // rotate until reaching angle
            while (deltaAngle < angle)
            {
                deltaAngle += rotationSpeed * Time.deltaTime;
                deltaAngle = Mathf.Min(deltaAngle, angle);

                transform.rotation = startRotation * Quaternion.AngleAxis(deltaAngle, axis);

                yield return null;
            }

            // delay here
            yield return new WaitForSeconds(1);
        }
  
}
    /*public float timer = 0f;
    public float TimeToTurn;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= TimeToTurn)
        {
            //transform.Rotate(transform.rotation.x, transform.rotation.y + 90, transform.rotation.z);
            StartCoroutine(RotateObject());
            
        }

    }
    IEnumerator RotateObject()
    {
        float speed = 10F;
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, 90, 0), Time.deltaTime * speed);
        timer = 0f;
        yield return null;
    }
     //    if (Input.GetKeyDown ("e")) {
     //    transform.Rotate(transform.rotation.x, transform.rotation.y+90,transform.rotation.z);
     //}*/
}
