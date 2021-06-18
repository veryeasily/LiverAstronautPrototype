using UnityEngine;
using UnityEngine.UI;
using Sirenix.OdinInspector;
using UnityAtoms;

public class ItemBehaviour : SerializedMonoBehaviour {
    public Image Image;
    public Image Background;
    public Image Border;

    private Specter _specter;
    [SerializeField] private SpecterVariable _currentSpecter;
    
    public static ItemBehaviour Create(Specter specter, Transform t) {
        var resource = Resources.Load<GameObject>("Prefabs/Specter");
        var obj = Instantiate(resource, t);
        var behaviour = obj.GetComponent<ItemBehaviour>();
        behaviour._specter = specter;
        behaviour.Render();
        return behaviour;
    }

    public void HandleSelected() {
        _currentSpecter.SetValue(_specter);
    }

    public void Destroy() {
        GameObject.Destroy(gameObject);
    }

    private void Render() {
        Image.sprite = _specter.Sprite;
        Background.color = _specter.Color;
        var isSelected = _specter == _currentSpecter.Value;
        Border.color = isSelected ? Color.magenta : Color.white;
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