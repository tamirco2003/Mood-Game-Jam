using UnityEngine;
using UnityEngine.Audio;
using System;

public class AudioManager : MonoBehaviour {
    
    public Sound[] sounds;

    void Awake() {
        foreach (Sound sound in sounds) {
            sound.source = gameObject.AddComponent<AudioSource>();
            sound.source.clip = sound.clip;
            sound.source.volume = sound.volume;
            sound.source.pitch = sound.pitch;
        }
    }

    public void Play(string name) {
        Sound sound = Array.Find(sounds, s => s.name == name);
        sound.source.PlayOneShot(sound.clip);
    }

    public Sound FindSound(string name) {
        Sound sound = Array.Find(sounds, s => s.name == name);
        return sound;
    }
}
