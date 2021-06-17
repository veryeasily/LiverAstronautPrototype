using System;
using JetBrains.Annotations;
using Sirenix.OdinInspector;
using UnityEngine.InputSystem;

public class GameController : SerializedMonoBehaviour {
    public static GameController Instance => _instance;
    private static GameController _instance;

    public PlayerController Player => GameState.Instance.Player;

    public void Awake() {
        if (_instance != null && _instance != this) {
            throw new Exception("Tried to create multiple instances");
        }

        _instance = this;
    }

    [UsedImplicitly]
    public void OnInput(InputAction.CallbackContext ctx) {
        switch (ctx.action.name) {
            case "Move": 
                if (!ctx.performed && !ctx.canceled) return;

                Player.OnMoveInput(ctx);
                break;
            case "Open":
                if (!ctx.performed) return;
                
                Player.OnOpenInput(ctx);
                break;
        }
    }
}