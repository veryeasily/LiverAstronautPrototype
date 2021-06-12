using System;
using DG.Tweening;
using UnityEngine;
using Sirenix.OdinInspector;

public class PositionBehaviour : SerializedMonoBehaviour {
    public bool IsFinished;
    public float Speed = 8f;
    public Vector3 Target = Vector3.zero;
    public Vector3 Source = Vector3.zero;
    public event Action<PositionBehaviour> OnMoveEnd;
    
    [NonSerialized] public Tween CurrentTween;

    public void Awake() {
        Source = transform.position;
    }

    public void Start() {
        PositionController.Instance.AddPosition(this);
    }

    public void MoveComplete() {
        CurrentTween = null;
        IsFinished = true;
        Source = transform.position;
        OnMoveEnd?.Invoke(this);
    }

    public void OnTriggerEnter2D(Collider2D other) {
        if (CurrentTween == null) return;

        CurrentTween.Kill();
        CurrentTween = null;
        IsFinished = true;
        Target = Source;
    }
}