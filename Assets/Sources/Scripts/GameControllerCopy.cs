using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameControllerCopy : SerializedMonoBehaviour {
    public static GameControllerCopy Instance => _instance;

    private Contexts _contexts;
    private GameFeature _gameFeature;
    private static GameControllerCopy _instance;


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

        var entity = _contexts.input.CreateEntity();
        entity.AddMovementInput(ctx.ReadValue<Vector2>());
    }


    private void Start() {
        _contexts = Contexts.sharedInstance;
        _contexts.SubscribeId();

        _gameFeature = new GameFeature(_contexts);
        _gameFeature.Initialize();
    }

    private void Update() {
        _gameFeature.Execute();
    }
}