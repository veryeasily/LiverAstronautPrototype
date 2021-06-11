using System;
using UnityEngine;
using Sirenix.OdinInspector;

public class PositionBehaviour : SerializedMonoBehaviour {
    public bool IsFinished;
    public float Speed = 8f;
    public Vector3 Target = Vector3.zero;
    public event Action<PositionBehaviour> OnMoveEnd;

    public void Start() {
        PositionController.Instance.AddPosition(this);
    }

    public void MoveComplete() {
        IsFinished = true;
        OnMoveEnd?.Invoke(this);
    }
}