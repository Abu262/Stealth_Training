using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotate : MonoBehaviour
{
    // Start is called before the first frame update
    public float turnSpeed = 4.0f;
    public Transform player;

    private Vector3 offset;

    void Start()
    {
        offset = new Vector3(player.position.x - 26.0f, player.position.y + 25.0f, player.position.z - 33.0f);


    }

    void LateUpdate()
    {


        if (Input.GetKey(KeyCode.Q))
        {
            offset = Quaternion.AngleAxis(-0.5f * turnSpeed, Vector3.up) * offset;
;
//            heading++;
  //          camPivot.rotation = Quaternion.Euler(0, heading + 1, 0);
        }
        if (Input.GetKey(KeyCode.E))
        {
            offset = Quaternion.AngleAxis(0.5f * turnSpeed, Vector3.up) * offset;
            
        }

        transform.position = player.position + offset;
        transform.LookAt(player.position);

    }
}
