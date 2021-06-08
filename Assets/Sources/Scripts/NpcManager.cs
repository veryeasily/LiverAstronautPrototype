using System;
using Sirenix.OdinInspector;
using System.Collections.Generic;

public class NpcManager : SerializedMonoBehaviour {
    public static NpcManager Instance { get; private set; }

    public List<Npc> npcs;

    public void Awake() {
        if (Instance != null && Instance != this) {
            throw new Exception("Tried to create multiple instances");
        }

        Instance = this;
    }

    public List<Npc> GetNpcs() {
        return npcs;
    }
}