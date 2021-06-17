using System;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Sirenix.OdinInspector;

public class ItemBehaviour : SerializedMonoBehaviour {
    public Image Image;
    public Image Background;
    public Image Border;

    private InventoryItem _inventoryItem;
    
    public static ItemBehaviour Create(InventoryItem inventoryItem, Transform t) {
        var resource = Resources.Load<GameObject>("Prefabs/InventoryItem");
        var obj = Instantiate(resource, t);
        var behaviour = obj.GetComponent<ItemBehaviour>();
        behaviour._inventoryItem = inventoryItem;
        // behaviour.Text.text = $"You picked up the\n{inventoryItem.ItemName}\nItem";
        // behaviour.Shift();
        behaviour.Render();
        return behaviour;
    }

    public void HandleSelected() {
        GameState.Instance.SelectedItem.Value = _inventoryItem;
    }

    public void Render() {
        Image.sprite = _inventoryItem.Sprite;
        Background.color = _inventoryItem.Color;
        if (_inventoryItem == GameState.Instance.SelectedItem.Value) {
            Border.color = Color.magenta;
        } else {
            Border.color = Color.white;
        }
    }

    public void Destroy() {
        GameObject.Destroy(gameObject);
    }

    // private void Shift() {
    //     var dir = Random.Range(0f, Mathf.PI * 2f);
    //     var x = Mathf.Max(Mathf.Cos(dir) * 16f, 0f);
    //     var y = Mathf.Min(Mathf.Sin(dir) * 16f, 0f);
    //     var vecDir = new Vector2(x, y);
    //     var target = transform.position + (Vector3)vecDir;
    //     var tween = transform.DOMove(target, 1.5f);
    //     tween.OnComplete(Shift);
    // }
}