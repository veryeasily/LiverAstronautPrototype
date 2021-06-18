using UnityAtoms;
using UnityEngine;
using System.Collections.Generic;

public class InventoryController : LiverBehaviour {
    public GameObject ItemPrefab;
    public GameObject InventoryContainer;
    public SpecterValueList Inventory;
    private readonly List<Item> _items = new List<Item>();

    public override void StartOrEnable() {
        HandleInventoryChange();
    }

    public void HandleInventoryChange() {
        foreach (var item in _items) {
            item.Unmount();
        }

        _items.Clear();

        foreach (var specter in Inventory) {
            _items.Add(CreateItem(specter));
        }
    }

    private Item CreateItem(Specter specter) {
        var parent = InventoryContainer.transform;
        var obj = Instantiate(ItemPrefab, parent);
        var item = obj.GetComponent<Item>();
        item.Specter.Value = specter;
        return item;
    }
}