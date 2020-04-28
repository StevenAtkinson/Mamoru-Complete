using UnityEngine.Audio;
using System;
using UnityEngine;
// the audio manager
public class AudioManager : MonoBehaviour
{
    // Declaring the variable 
    public Sound[] sounds;

    void Awake()
    {

        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            // adding volume, pitch and loop controllers
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }
    }
    // Play sound function
    public void Play(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        s.source.Play();

        if (PauseMenu.GameIsPaused)
        {
            s.source.pitch *= .5f;
        }
    }
}