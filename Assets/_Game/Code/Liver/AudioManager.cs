using System;
using System.Collections;
using UnityEngine;
using Sirenix.OdinInspector;

[RequireComponent(typeof(AudioSource))]
public class AudioManager : SerializedMonoBehaviour {
    public static AudioManager Instance => _instance;
    private static AudioManager _instance;

    public event Action<AudioClip> OnClipFinished;
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

    public void Play(AudioClip clip, float delay = 0f) {
        StartCoroutine(DoPlayOneShot(clip, delay));
    }

    private IEnumerator DoPlayOneShot(AudioClip clip, float delay = 0f) {
        yield return new WaitForSeconds(delay);
        
        var duration = clip.length;
        _source.PlayOneShot(clip);
        yield return new WaitForSeconds(duration);
        
        OnClipFinished?.Invoke(clip);
    }
}