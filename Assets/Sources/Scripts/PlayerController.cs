using System;
using UnityEngine;
using Sirenix.OdinInspector;
using UnityEngine.InputSystem;

public class PlayerController : SerializedMonoBehaviour {
    public GameController GameController;
    private PositionBehaviour _positionBehaviour;

    public void Start() {
        _positionBehaviour = GetComponent<PositionBehaviour>();
    }

    public void OnEnable() {
        GameController.OnMoveInput += OnMoveInput;
    }

    public void OnDisable() {
        GameController.OnMoveInput -= OnMoveInput;
    }

    private void OnMoveInput(InputAction.CallbackContext ctx) {
        if (GameController.isDialoguePlaying) return;
        
        var vec = ctx.ReadValue<Vector2>();
        _positionBehaviour.Target.x += (int) vec.x;
        _positionBehaviour.Target.y += (int) vec.y;
    }
}