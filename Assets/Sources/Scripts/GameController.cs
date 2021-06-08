using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameController : SerializedMonoBehaviour {
    public static GameController Instance => _instance;
    private static GameController _instance;

    public GameConfig gameConfig;
    public bool isDialoguePlaying;
    public event Action<InputAction.CallbackContext> OnMoveInput;

    private void Awake() {
        if (_instance != null && _instance != this) {
            throw new Exception("Tried to create multiple instances");
        }

        _instance = this;
    }

    [UsedImplicitly]
    public void OnInput(InputAction.CallbackContext ctx) {
        UnityLogger.LogObject(ctx);
        if (!ctx.performed && !ctx.canceled) return;

        OnMoveInput?.Invoke(ctx);
    }

    public void SetIsDialoguePlaying(bool isPlaying) {
        isDialoguePlaying = isPlaying;
    }

    private void OnDialogueStart(object obj) {
        SetIsDialoguePlaying(true);
    }
}