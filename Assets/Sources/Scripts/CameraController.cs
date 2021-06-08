using System;
using UnityEngine;
using Sirenix.OdinInspector;
using UnityEngine.InputSystem;

public class CameraController : SerializedMonoBehaviour {
    public Camera mainCamera;
    public float moveSpeed = 5f;
    public PlayerController playerController;

    private Vector3 _gridTarget = Vector3.zero;

    public void Start() {
        var position = transform.position;
        _gridTarget = Vector3.zero;
        _gridTarget.x = (int) position.x;
        _gridTarget.y = (int) position.y;
        _gridTarget.z = (int) position.z;
    }

    public void OnEnable() {
        playerController.OnMoveFinished += OnMoveFinished;
    }

    public void OnDisable() {
        playerController.OnMoveFinished -= OnMoveFinished;
    }

    public void Update() {
        var maxMove = moveSpeed * Time.deltaTime;
        var vec = Vector3.MoveTowards(transform.localPosition, _gridTarget, maxMove);
        transform.position = vec;
    }

    private void OnMoveFinished(Vector3 playerVec) {
        var result = (int) Mathf.Floor(playerVec.x / 16);
        _gridTarget.x = result * 16 + 8;
    }
}