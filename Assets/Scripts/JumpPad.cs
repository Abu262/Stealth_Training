using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpPad : MonoBehaviour
{
    
    public float JumpForce = 2000f;

    void OnTriggerEnter(Collider col)
    {
        //Debug.Log("Entered");
        if (col.gameObject.tag == "Player")
        {
            if (GameObject.Find("AudioManager") != null)
            {
                AudioManager.instance.Play("PlayerJump");
            }
            col.GetComponent<Rigidbody>().AddForce(0, JumpForce, 0);
        }

    }
}
