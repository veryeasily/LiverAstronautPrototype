using System;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

public class InventoryController : LiverBehaviour {
    public GameObject InventoryContainer;

    private IDisposable _moveObserver;
    private IDisposable _changeObserver;
    private IDisposable _selectedObserver;
    private readonly List<ItemBehaviour> _items = new List<ItemBehaviour>();

    private static GameState _state => GameState.Instance;

    public void OnDisable() {
        _moveObserver.Dispose();
        _changeObserver.Dispose();
        _selectedObserver.Dispose();
    }

    public override void StartOrEnable() {
        _moveObserver = _state.Inventory.ObserveMove().Subscribe(_ => HandleInventoryChange());
        _changeObserver = _state.Inventory.ObserveCountChanged().Subscribe(_ => HandleInventoryChange());
        _selectedObserver = _state.SelectedItem.Subscribe(_ => HandleInventoryChange());
        HandleInventoryChange();
    }

    private void HandleInventoryChange() {
        foreach (var itemBehaviour in _items) {
            itemBehaviour.Destroy();
        }
        _items.Clear();

        var t = InventoryContainer.transform;
        foreach (var item in _state.Inventory) {
            _items.Add(ItemBehaviour.Create(item, t));
        }
    }
}