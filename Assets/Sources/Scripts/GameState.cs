using System;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UniRx;

public class GameState : SerializedMonoBehaviour {
    public static GameState Instance => _instance;
    private static GameState _instance;

    public GameConfig GameConfig;
    public bool IsDialoguePlaying;

    public List<NpcBehaviour> Npcs = new List<NpcBehaviour>();
    public List<ObstacleBehaviour> Enemies = new List<ObstacleBehaviour>();

    public ReactiveCollection<NpcBehaviour> Inventory = new ReactiveCollection<NpcBehaviour>();

    public event Action OnDialogueEnd;
    public event Action OnDialogueStart;
    
    public void Awake() {
        if (_instance != null && _instance != this) {
            throw new Exception("Tried to create multiple instances");
        }

        _instance = this;
    }

    public void AddInventory(NpcBehaviour npc) {
        Inventory.Add(npc);
    }

    public void DialogueStart() {
        IsDialoguePlaying = true;
        OnDialogueStart?.Invoke();
    }

    public void DialogueEnd() {
        IsDialoguePlaying = false;
        OnDialogueEnd?.Invoke();
    }
}