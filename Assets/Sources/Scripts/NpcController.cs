using System;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using System.Linq;
using UnityAtoms;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;
using Yarn.Unity;

public class NpcController : SerializedMonoBehaviour {
    public GameState State;
    public PlayerController Player;
    public SpecterValueList Inventory;

    private GameConfig _gameConfig;
    private SpeakerBehaviour _currentSpeaker;
    private DialogueController _dialogueController;

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
        if (!_currentSpeaker) {
            return;
        }

        var specter = _currentSpeaker.NpcSpeaker.Specter;
        Inventory.Add(specter);
        _currentSpeaker = null;
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

    private void ActivateForNpc(SpeakerBehaviour npc) {
        _dialogueController.ActivateForDialogue(npc.NpcSpeaker);
        npc.WasVisited = true;
        _currentSpeaker = npc;
    }

    private IEnumerable<SpeakerBehaviour> GetUnvisitedNpcs() {
        var allNpcs = GameState.Instance.Npcs;
        return from npc in allNpcs where !npc.WasVisited select npc;
    }
}