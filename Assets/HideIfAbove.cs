using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideIfAbove : MonoBehaviour
{

    public Transform WatchTarget;

    //This is the material with the Transparent/Diffuse With Shadow shader
    public Material HiderMaterial;
    public Material RealMaterial;

    // Start is called before the first frame update
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        Hide();
    }


    void Hide()
    {
        if( transform.position.y > WatchTarget.position.y)
        {
            gameObject.GetComponent<Renderer>().material = HiderMaterial;
        }
        else
        {
            gameObject.GetComponent<Renderer>().material = RealMaterial;
        }
    }


}
