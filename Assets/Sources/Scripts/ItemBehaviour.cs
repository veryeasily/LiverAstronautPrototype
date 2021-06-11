using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.UI;

public class ItemBehaviour : SerializedMonoBehaviour {
    public static ItemBehaviour Create(NpcBehaviour npc, Transform t) {
        var resource = Resources.Load<GameObject>("Prefabs/InventoryItem");
        var obj = Instantiate(resource, t);
        var image = obj.GetComponent<Image>();
        var behaviour = obj.GetComponent<ItemBehaviour>();
        image.color = npc.Color;
        return behaviour;
    }

    public void Destroy() {
        Destroy(gameObject);
    }
}