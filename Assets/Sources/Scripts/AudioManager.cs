using System;
using UnityEngine;
using Sirenix.OdinInspector;

[RequireComponent(typeof(AudioSource))]
public class AudioManager : SerializedMonoBehaviour {
    public static AudioManager Instance => _instance;
    private static AudioManager _instance;
    
    private AudioSource _source;
    
    public void Awake() {
        if (_instance != null && _instance != this) {
            throw new Exception("Tried to create multiple instances");
        }

        _instance = this;
    }

    public void Start() {
        _source = GetComponent<AudioSource>();
    }

    public void Play(AudioClip clip) {
        _source.clip = clip;
        _source.Play();
    }
}