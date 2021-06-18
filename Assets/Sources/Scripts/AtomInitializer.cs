using UnityAtoms;
using Sirenix.OdinInspector;
using System.Collections.Generic;

public class AtomInitializer : SerializedMonoBehaviour {
    public SpecterValueList Inventory;
    public List<Specter> InitialInventory;

    public void Awake() {
        Inventory.List = InitialInventory;
    }
}