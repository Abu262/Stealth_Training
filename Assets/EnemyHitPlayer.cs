using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class EnemyHitPlayer : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
            
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision other)
    {
        //other.name should equal the root of your Player object
        if (other.gameObject.name == "Player")
        {
            AudioManager.instance.Play("PlayerCaught");

            //The scene number to load (in File->Build Settings)
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

    }
}
