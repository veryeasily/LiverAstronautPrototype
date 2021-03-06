using System;
using UnityEngine;
using Sirenix.OdinInspector;
using UnityEngine.InputSystem;

public class PlayerController : SerializedMonoBehaviour {
    public ThoughtBalloon Balloon;
    public event Action<PositionBehaviour> OnPlayerMoveEnd;
    
    private BoxCollider2D _collider;
    private PositionBehaviour _positionBehaviour;

    public void Start() {
        _collider = GetComponent<BoxCollider2D>();
    }

    public void OnEnable() {
        _positionBehaviour = GetComponent<PositionBehaviour>();
        _positionBehaviour.OnMoveEnd += HandleMoveEnd;
    }

    public void OnDisable() {
        _positionBehaviour.OnMoveEnd -= HandleMoveEnd;
    }

    public void OnMoveInput(InputAction.CallbackContext ctx) {
        if (GameState.Instance.IsDialoguePlaying) return;
        
        var vec = ctx.ReadValue<Vector2>();
        _positionBehaviour.Target.x += (int) vec.x;
        _positionBehaviour.Target.y += (int) vec.y;
    }

    public void OnOpenInput(InputAction.CallbackContext ctx) {
        if (GameState.Instance.IsDialoguePlaying) return;
        
        Debug.Log("OPEN!!");
    }

    private void HandleMoveEnd(PositionBehaviour position) {
        OnPlayerMoveEnd?.Invoke(position);
    }
}