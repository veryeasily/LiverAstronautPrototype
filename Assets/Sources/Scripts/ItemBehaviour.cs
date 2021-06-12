using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Sirenix.OdinInspector;

public class ItemBehaviour : SerializedMonoBehaviour {
    public TMP_Text Text;
    
    public static ItemBehaviour Create(NpcBehaviour npc, Transform t) {
        var resource = Resources.Load<GameObject>("Prefabs/InventoryItem");
        var obj = Instantiate(resource, t);
        var image = obj.GetComponent<Image>();
        var behaviour = obj.GetComponent<ItemBehaviour>();
        image.color = npc.Color;
        behaviour.Text.text = $"You picked up the\n{npc.characterName}\nItem";
        behaviour.Shift();
        return behaviour;
    }

    public void Destroy() {
        Destroy(gameObject);
    }

    private void Shift() {
        var dir = Random.Range(0f, Mathf.PI * 2f);
        var x = Mathf.Max(Mathf.Cos(dir) * 16f, 0f);
        var y = Mathf.Min(Mathf.Sin(dir) * 16f, 0f);
        var vecDir = new Vector2(x, y);
        var target = transform.position + (Vector3)vecDir;
        var tween = transform.DOMove(target, 1.5f);
        tween.OnComplete(Shift);
    }
}