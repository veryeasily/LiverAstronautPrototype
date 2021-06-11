using System;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using System.Linq;
using UnityEngine.UI;
using Yarn.Unity;

public class NpcController : SerializedMonoBehaviour {
    public static NpcController Instance => _instance;
    private static NpcController _instance;

    public PlayerController Player;
    
    public Image DialoguePortrait;
    public DialogueRunner DialogueRunner;

    private NpcBehaviour _currentCharacter;
    private GameState _gameState;
    private GameConfig _gameConfig;

    public void Awake() {
        if (_instance != null && _instance != this) {
            throw new Exception("Tried to create multiple instances");
        }

        _instance = this;
    }

    public void Start() {
        _gameState = GameState.Instance;
        _gameConfig = _gameState.GameConfig;
    }

    public void OnEnable() {
        Player.OnPlayerMoveEnd += HandlePlayerMoveEnd;
    }

    public void OnDisable() {
        Player.OnPlayerMoveEnd -= HandlePlayerMoveEnd;
    }

    public void HandleDialogueStart() {
        _gameState.IsDialoguePlaying = true;
    }

    public void HandleDialogueEnd() {
        if (!_currentCharacter) {
            throw new Exception("Tried to end dialogue while there was no current character");
        }
        
        _gameState.IsDialoguePlaying = false;
        GameState.Instance.AddInventory(_currentCharacter);
        _currentCharacter = null;
    }

    private void HandlePlayerMoveEnd(object ignore) {
        CheckNpcDialogue();
    }

    private void CheckNpcDialogue() {
        if (_gameState.IsDialoguePlaying) return;

        var npcs = GetUnvisitedNpcs();
        foreach (var npc in npcs) {
            var inRange = npc.CheckDistance(Player, _gameConfig.DialogueDistance);
            if (!inRange) continue;
            
            ActivateForNpc(npc);
            break;
        }
    }

    private void ActivateForNpc(NpcBehaviour npc) {
        DialoguePortrait.sprite = npc.sprite;
        DialogueRunner.Stop();
        DialogueRunner.Clear();
        DialogueRunner.Add(npc.dialogue);
        DialogueRunner.StartDialogue();
        npc.WasVisited = true;
        _currentCharacter = npc;
    }

    private IEnumerable<NpcBehaviour> GetUnvisitedNpcs() {
        var allNpcs = GameState.Instance.Npcs;
        return from npc in allNpcs where !npc.WasVisited select npc;
    }
}