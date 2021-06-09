using System;
using UnityEngine;
using Sirenix.OdinInspector;

public class PositionBehaviour : SerializedMonoBehaviour {
    public float Speed = 8f;
    public bool IsFinished = false;
    public Vector3 Target = Vector3.zero;
    public event Action<PositionBehaviour> OnMoveComplete;

    public void Start() {
        PositionController.Instance.AddPosition(this);
    }

    public void MoveComplete() {
        IsFinished = true;
        OnMoveComplete?.Invoke(this);
    }
}