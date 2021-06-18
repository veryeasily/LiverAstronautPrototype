using UnityAtoms;
using UnityEngine;
using System.Collections.Generic;

public class InventoryController : LiverBehaviour {
    public GameObject InventoryContainer;
    public SpecterValueList Inventory;
    private readonly List<ItemBehaviour> _items = new List<ItemBehaviour>();

    public override void StartOrEnable() {
        HandleInventoryChange();
    }

    public void HandleInventoryChange() {
        foreach (var item in _items) {
            item.Destroy();
        }

        _items.Clear();

        var t = InventoryContainer.transform;
        foreach (var specter in Inventory) {
            _items.Add(ItemBehaviour.Create(specter, t));
        }
    }
}