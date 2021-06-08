using System;
using System.Collections.Generic;
using JetBrains.Annotations;
using Sirenix.OdinInspector;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;
using Yarn.Unity;

public class DialogueController : SerializedMonoBehaviour {
    public static DialogueController Instance => _instance;
    private static DialogueController _instance;

    public NpcManager npcManager;
    public PlayerController player;
    public DialogueRunner dialogueRunner;
    
    private GameConfig _gameConfig;
    private readonly List<Npc> _visitedNpcs = new List<Npc>();

    public void Awake() {
        if (_instance != null && _instance != this) {
            throw new Exception("Tried to create multiple instances");
        }

        _instance = this;
    }

    public void Start() {
        _gameConfig = GameController.Instance.gameConfig;
    }

    public void Update() {
        CheckNpcDialogue();
    }

    private void CheckNpcDialogue() {
        if (GameController.Instance.isDialoguePlaying) return;

        var npcs = GetUnvisitedNpcs();
        foreach (var npc in npcs) {
            var inRange = npc.CheckDistance(player, _gameConfig.dialogueDistance);
            if (!inRange) continue;
            
            dialogueRunner.Stop();
            dialogueRunner.Clear();
            dialogueRunner.Add(npc.dialogue);
            dialogueRunner.StartDialogue();
            _visitedNpcs.Add(npc);
            break;
        }
    }

    private IEnumerable<Npc> GetUnvisitedNpcs() {
        return from npc in npcManager.GetNpcs() where !_visitedNpcs.Contains(npc) select npc;
    }
}