using UniRx;
using System;
using UnityAtoms;
using Sirenix.OdinInspector;
using System.Collections.Generic;
using UnityEngine;

public class AtomInitializer : SerializedMonoBehaviour {
    public SpecterValueList Inventory;
    public List<Specter> InitialInventory;

    private readonly List<IDisposable> _listeners = new List<IDisposable>();

    public void Awake() {
        Inventory.List = InitialInventory;
    }

    public void Start() {
        Debug.Log("Start!!");
        _listeners.Add(Inventory.ObserveAdd().Subscribe(_ => ChangeInventory()));
        _listeners.Add(Inventory.ObserveRemove().Subscribe(_ => ChangeInventory()));
        _listeners.Add(Inventory.ObserveClear().Subscribe(_ => ChangeInventory()));
    }

    public void OnDestroy() {
        _listeners.ForEach(listener => listener.Dispose());
    }

    private void ChangeInventory() {
        Debug.Log(Inventory.List);
    }
}