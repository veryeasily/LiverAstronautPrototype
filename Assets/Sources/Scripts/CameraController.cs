using System;
using UnityEngine;
using Sirenix.OdinInspector;
using UnityEngine.InputSystem;

public class CameraController : SerializedMonoBehaviour {
    public Camera MainCamera;
    public PlayerController PlayerController;
    
    private PositionBehaviour _positionBehaviour;

    public void Start() {
        _positionBehaviour = GetComponent<PositionBehaviour>();
    }

    public void OnEnable() {
        var behaviour = PlayerController.GetComponent<PositionBehaviour>();
        behaviour.OnMoveComplete += OnMoveFinished;
    }

    public void OnDisable() {
        var behaviour = PlayerController.GetComponent<PositionBehaviour>();
        behaviour.OnMoveComplete -= OnMoveFinished;
    }

    private void OnMoveFinished(PositionBehaviour position) {
        var vec = position.gameObject.transform.position;
        var result = (int) Mathf.Floor(vec.x / 16);
        Debug.Log($"QWERASDF={result}");
        _positionBehaviour.Target.x = result * 16 + 8;
    }
}