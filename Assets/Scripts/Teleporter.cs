using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporter : MonoBehaviour
{
    public Teleporter destination;
    private Transform justJumpedSubject;

    void JumpToMe(Transform subject)
    {
        subject.transform.position = transform.position;
        justJumpedSubject = subject;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.transform != justJumpedSubject)
        {
            AudioManager.instance.Play("PlayerJump");
            destination.JumpToMe(other.transform);

        }
    }
    void OnTriggerExit(Collider other)
    {
        if(other.transform == justJumpedSubject)
        {
            justJumpedSubject = null;
        }
    }
}
