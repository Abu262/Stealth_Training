using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpPad : MonoBehaviour
{
    public AudioSource js;
    public float JumpForce = 2000f;
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
        if (col.gameObject.tag == "Player")
        {
            js.Play();
            col.GetComponent<Rigidbody>().AddForce(0, JumpForce, 0);
        }

    }
}
