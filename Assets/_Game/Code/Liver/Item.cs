using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Sirenix.OdinInspector;
using UniRx;
using UnityAtoms;

public class Item : SerializedMonoBehaviour {
    public Image Image;
    public Image Background;
    public Image Border;
    public SpecterReference Specter;

    [SerializeField] private SpecterReference _currentSpecter;
    private Color _color => Specter.Value.Color;
    private Sprite _sprite => Specter.Value.Sprite;
    private Color _borderColor => Specter.Value == _currentSpecter.Value ? Color.magenta : Color.white;

    public void HandleSelected() {
        _currentSpecter.Value = Specter.Value;
    }

    public void Render() {
        Image.sprite = _sprite;
        Background.color = _color;
        Border.color = _borderColor;
    }

    public void Unmount() {
        Destroy(gameObject);
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