using UnityEngine.Audio;
using System;
using UnityEngine;
using System.Collections;

public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;
    Sound bgm;
    public static AudioManager instance;
    float v;
    int target = 30;
    // Start is called before the first frame update
    void Awake()
    {
        Application.targetFrameRate = target;
        QualitySettings.vSyncCount = 0;
        if (instance == null)
            instance = this;
        else
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);

        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }
    }


    void Update()
    {
        if (Application.targetFrameRate != target)
        {
            Application.targetFrameRate = target;
        }

      if (!bgm.source.isPlaying)
        {
            bgm = sounds[UnityEngine.Random.Range(4, 13)];
            PlayBgm(bgm.name);
        }
        fadeIn();
    }


    void Start()
    {
       bgm = Array.Find(sounds, sound => sound.name == "Bu-op");
        PlayBgm("Bu-op");

    }
    public void Play (string name)
    {
        Debug.Log("DID IT");
        Sound s = Array.Find(sounds, sound => sound.name == name);

        if (s == null)
            return;
        s.source.Play();
    }

    public void PlayBgm(string name)
    {
        v = 0f;
        Sound s = Array.Find(sounds, sound => sound.name == name);
        s.source.volume = 0f;
        if (s == null)
            return;
        s.source.Play();
    }

    void fadeIn()
    {
        
        
        bgm.volume = v;
        if (v < 0.5f)
        {
            v += 0.1f *Time.deltaTime;
            bgm.volume = v;
            bgm.source.volume = bgm.volume;
            Debug.Log(bgm.volume);
        }

    }

}
