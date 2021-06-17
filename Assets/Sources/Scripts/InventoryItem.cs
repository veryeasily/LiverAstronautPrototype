using UnityEngine;
using Sirenix.OdinInspector;

[CreateAssetMenu(fileName = "NewInventoryItem", menuName = "Liver/InventoryItem")]
public class InventoryItem : SerializedScriptableObject {
    public Color Color;
    public Sprite Sprite;
    public string ItemName;
}