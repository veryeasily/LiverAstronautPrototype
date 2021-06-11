using System;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

public class InventoryController : SerializedMonoBehaviour {
    public GameObject InventoryContainer;
    public GameObject InventoryItemPrefab;

    private IDisposable _moveObserver;
    private IDisposable _changeObserver;
    private List<ItemBehaviour> _items = new List<ItemBehaviour>();

    private bool _started;
    private ReactiveCollection<NpcBehaviour> _inventory => GameState.Instance.Inventory;
    
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
    }

    private void StartOrEnable() {
        _moveObserver = _inventory.ObserveMove().Subscribe(_ => HandleInventoryChange());
        _changeObserver = _inventory.ObserveCountChanged().Subscribe(_ => HandleInventoryChange());
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