using System;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using Yarn.Unity;

public class NpcController : SerializedMonoBehaviour {
    public static NpcController Instance => _instance;
    private static NpcController _instance;

    public PlayerController Player;

    public GameState State;
    private GameConfig _gameConfig;
    private NpcBehaviour _currentCharacter;
    private DialogueController _dialogueController;

    public void Awake() {
        if (_instance != null && _instance != this) {
            throw new Exception("Tried to create multiple instances");
        }

        _instance = this;
    }

    public void Start() {
        _gameConfig = State.GameConfig;
        
        var dialogueObj = GameObject.FindWithTag("DialogueController");
        _dialogueController = dialogueObj.GetComponent<DialogueController>();
    }

    public void OnEnable() {
        Player.OnPlayerMoveEnd += HandlePlayerMoveEnd;
        State.OnDialogueEnd += HandleDialogueEnd;
    }

    public void OnDisable() {
        Player.OnPlayerMoveEnd -= HandlePlayerMoveEnd;
        State.OnDialogueEnd -= HandleDialogueEnd;
    }

    public void HandleDialogueEnd() {
        if (!_currentCharacter) {
            return;
        }

        GameState.Instance.AddInventory(_currentCharacter);
        _currentCharacter = null;
    }

    private void HandlePlayerMoveEnd(object ignore) {
        CheckNpcDialogue();
    }

    private void CheckNpcDialogue() {
        if (State.IsDialoguePlaying) return;

        var npcs = GetUnvisitedNpcs();
        foreach (var npc in npcs) {
            var inRange = npc.CheckDistance(Player, _gameConfig.DialogueDistance);
            if (!inRange) continue;

            ActivateForNpc(npc);
            break;
        }
    }

    private void ActivateForNpc(NpcBehaviour npc) {
        _dialogueController.ActivateForDialogue(npc);
        npc.WasVisited = true;
        _currentCharacter = npc;
    }

    private IEnumerable<NpcBehaviour> GetUnvisitedNpcs() {
        var allNpcs = GameState.Instance.Npcs;
        return from npc in allNpcs where !npc.WasVisited select npc;
    }
}