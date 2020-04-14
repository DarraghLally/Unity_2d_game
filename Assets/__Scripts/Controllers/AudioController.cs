using UnityEngine.Audio;
using UnityEngine;
using System;

// == The code from this class was used and 
// modified for my project from YouTube Tutorials by
// Brackeys ==

public class AudioController : MonoBehaviour
{
    // To hold our sounds
    public Sound[] sounds;

    // Called before start
    void Awake()
    {
        // Give every sound in our array these controls
        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
        }
    }

    void Start() {
        Play("Wind");
    }
  
    // Play method finds the appropriate sound in our array and plays it.
    public void Play(string name)
    {
       Sound s = Array.Find(sounds, sound => sound.name == name);
       s.source.Play();
    }
}
