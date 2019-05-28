using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideEnemyVisionCone : MonoBehaviour
{
    public Material Hidden;
    public Material NotHidden;
    Transform player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y > player.position.y + 3f)
        {
            gameObject.GetComponent<Renderer>().material = Hidden;
        }
        else
        {
            gameObject.GetComponent<Renderer>().material = NotHidden;
        }
    }
}
