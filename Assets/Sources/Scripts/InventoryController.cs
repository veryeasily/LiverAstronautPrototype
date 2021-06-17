using System;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UniRx;
using UnityEngine;

public class InventoryController : SerializedMonoBehaviour {
    public GameObject InventoryContainer;
    public GameObject InventoryItemPrefab;

    private IDisposable _moveObserver;
    private IDisposable _changeObserver;
    private IDisposable _selectedObserver;
    private List<ItemBehaviour> _items = new List<ItemBehaviour>();

    private bool _started;
    private ReactiveCollection<InventoryItem> _inventory => GameState.Instance.Inventory;
    
    public void OnEnable() {
        if (_started) {
            StartOrEnable();
        }
    }

    public void Start() {
        if (enabled) {
            StartOrEnable();
        }
        _started = true;
    }

    public void OnDisable() {
        _moveObserver.Dispose();
        _changeObserver.Dispose();
        _selectedObserver.Dispose();
    }

    private void StartOrEnable() {
        _moveObserver = _inventory.ObserveMove().Subscribe(_ => HandleInventoryChange());
        _changeObserver = _inventory.ObserveCountChanged().Subscribe(_ => HandleInventoryChange());
        _selectedObserver = GameState.Instance.SelectedItem.Subscribe(_ => HandleInventoryChange());
        HandleInventoryChange();
    }

    private void HandleInventoryChange() {
        foreach (var itemBehaviour in _items) {
            itemBehaviour.Destroy();
        }
        _items.Clear();

        var t = InventoryContainer.transform;
        foreach (var item in _inventory) {
            _items.Add(ItemBehaviour.Create(item, t));
        }
    }
}