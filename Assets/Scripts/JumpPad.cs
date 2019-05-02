using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpPad : MonoBehaviour
{
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider col)
    {
        //Debug.Log("Entered");
        col.GetComponent<Rigidbody>().AddForce(0,2000,0);
    }
}
