using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerColliding : MonoBehaviour
{
    public bool PlayerTouching = false;
    public Material material1;
    public Material material2;
    Renderer rend;
    bool PlayerAlarm = false;
    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<Renderer>();
        rend.material = material1;
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerAlarm)
        {
            AudioManager.instance.sounds[1].loop = true;
            AudioManager.instance.sounds[1].source.volume = AudioManager.instance.sounds[1].volume;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        var lerp = Mathf.PingPong(Time.time, 5) / 5;
        if (other.tag == "Player")
        {
            AudioManager.instance.Play("Alarm");
            PlayerAlarm = true;
            rend.material.Lerp(material1, material2, 1);
            // do shit
            PlayerTouching = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        var lerp = Mathf.PingPong(Time.time, 5) / 5;
        if (other.tag == "Player")
        {
            PlayerAlarm = false;
            AudioManager.instance.sounds[1].source.volume = 0f;
            AudioManager.instance.sounds[1].loop = false;
            
            rend.material.Lerp(material2, material1, 1);
            // do shit
            PlayerTouching = false;
        }
    }
}
