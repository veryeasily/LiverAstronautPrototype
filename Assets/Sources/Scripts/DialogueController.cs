using System;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using System.Linq;
using UnityEngine.UI;
using Yarn.Unity;

public class DialogueController : SerializedMonoBehaviour {
    public static DialogueController Instance => _instance;
    private static DialogueController _instance;

    public NpcManager npcManager;
    public PlayerController player;
    public InventoryController inventory;
    
    public Image dialoguePortrait;
    public DialogueRunner dialogueRunner;

    private Npc _currentCharacter;
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

    public void EndDialogue() {
        if (!_currentCharacter) {
            throw new Exception("Tried to end dialogue while there was no current character");
        }
        
        inventory.Add(_currentCharacter);
        _currentCharacter = null;
    }

    private void CheckNpcDialogue() {
        if (GameController.Instance.isDialoguePlaying) return;

        var npcs = GetUnvisitedNpcs();
        foreach (var npc in npcs) {
            var inRange = npc.CheckDistance(player, _gameConfig.dialogueDistance);
            if (!inRange) continue;
            
            ActivateForNpc(npc);
            break;
        }
    }

    private void ActivateForNpc(Npc npc) {
        dialoguePortrait.sprite = npc.sprite;
        dialogueRunner.Stop();
        dialogueRunner.Clear();
        dialogueRunner.Add(npc.dialogue);
        dialogueRunner.StartDialogue();
        _visitedNpcs.Add(npc);
        _currentCharacter = npc;
    }

    private IEnumerable<Npc> GetUnvisitedNpcs() {
        return from npc in npcManager.GetNpcs() where !_visitedNpcs.Contains(npc) select npc;
    }
}