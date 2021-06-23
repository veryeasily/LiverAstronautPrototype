using UnityEngine;
using Sirenix.OdinInspector;

public class Sound : SerializedMonoBehaviour {
    public float Delay;
    public AudioClip Audio;

    public void Start() {
        AudioManager.Instance.Play(Audio, Delay);
    }
}