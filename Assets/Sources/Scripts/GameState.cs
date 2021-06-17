using System;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UniRx;

public class GameState : SerializedMonoBehaviour {
    public static GameState Instance => _instance;
    private static GameState _instance;

    public GameConfig GameConfig;
    public bool IsDialoguePlaying;
    public PlayerController Player;
    public PositionBehaviour PlayerPosition;

    public List<NpcBehaviour> Npcs = new List<NpcBehaviour>();
    public List<ObstacleBehaviour> Obstacles = new List<ObstacleBehaviour>();

    public InventoryItem Dad;
    public InventoryItem Teacher;
    public ReactiveCollection<InventoryItem> Inventory = new ReactiveCollection<InventoryItem>();

    public ReactiveProperty<InventoryItem> SelectedItem = new ReactiveProperty<InventoryItem>();

    public event Action OnDialogueEnd;
    public event Action OnDialogueStart;
    
    public void Awake() {
        if (_instance != null && _instance != this) {
            throw new Exception("Tried to create multiple instances");
        }

        _instance = this;
        
        Inventory.Add(Dad);
        Inventory.Add(Teacher);
    }

    public void AddInventory(InventoryItem item) {
        Inventory.Add(item);
    }

    public void TriggerDialogueStart() {
        OnDialogueStart?.Invoke();
    }

    public void TriggerDialogueEnd() {
        OnDialogueEnd?.Invoke();
    }
}