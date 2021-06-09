using System;
using Sirenix.OdinInspector;
using System.Collections.Generic;

public class InventoryController : SerializedMonoBehaviour {
    public static InventoryController Instance => _instance;
    private static InventoryController _instance;
    
    public PlayerController player;
    public Dictionary<string, Npc> Inventory = new Dictionary<string, Npc>();
    
    public void Awake() {
        if (_instance != null && _instance != this) {
            throw new Exception("Tried to create multiple instances");
        }

        _instance = this;
    }

    public void Add(Npc npc) {
        Inventory[npc.characterName] = npc;
    }

    public bool Has(Npc npc) {
        return Inventory.ContainsKey(npc.characterName);
    }
}