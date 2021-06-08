using System;
using UnityEngine;
using Sirenix.OdinInspector;
using UnityEngine.InputSystem;

public class PlayerController : SerializedMonoBehaviour {
    public float moveSpeed = 5f;
    public GameController gameController;
    public event Action<Vector3> OnMoveFinished;

    private Vector3 _gridTarget;
    private bool _isMoveFinished = true;

    public void Start() {
        var position = transform.position;
        _gridTarget = Vector3.zero;
        _gridTarget.x = (int) position.x;
        _gridTarget.y = (int) position.y;
        _gridTarget.z = (int) position.z;
    }

    public void OnEnable() {
        gameController.OnMoveInput += OnMoveInput;
    }

    public void OnDisable() {
        gameController.OnMoveInput -= OnMoveInput;
    }

    public void Update() {
        var maxMove = moveSpeed * Time.deltaTime;
        var vec = Vector3.MoveTowards(transform.localPosition, _gridTarget, maxMove);
        transform.position = vec;
        CheckMoveFinished();
    }

    private void OnMoveInput(InputAction.CallbackContext ctx) {
        if (gameController.isDialoguePlaying) return;
        
        var vec = ctx.ReadValue<Vector2>();
        _gridTarget.x += (int) vec.x;
        _gridTarget.y += (int) vec.y;
    }

    private void CheckMoveFinished() {
        var prev = _isMoveFinished;
        _isMoveFinished = _gridTarget == transform.localPosition;
        
        if (prev != _isMoveFinished && _isMoveFinished) {
            OnMoveFinished?.Invoke(transform.position);
        }
    }
}