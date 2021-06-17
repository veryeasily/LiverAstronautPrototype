using System;
using DG.Tweening;
using UnityEngine;
using Sirenix.OdinInspector;

public class ObstacleBehaviour : SerializedMonoBehaviour {
    public bool IsDefeated;
    public InventoryItem weakness;
    public Sprite sprite;
    public YarnProgram dialogue;
    public string characterName;
    public AudioClip SuccessClip;
    public SpriteRenderer Renderer;
    public event Action<ObstacleBehaviour> OnDefeated;

    private Tween _tween;

    public void Start() {
        GameState.Instance.Obstacles.Add(this);
    }

    public void OnDestroy() {
        if (_tween != null) {
            _tween.Kill();
        }
    }

    public bool CheckDistance(PlayerController player, float maxDistance) {
        var position = transform.position;
        var playerPosition = player.transform.position;
        var distance = Vector3.SqrMagnitude(position - playerPosition);
        return distance <= maxDistance;
    }

    public void AttemptSuccess() {
        var canDefeat = GameState.Instance.Inventory.Contains(weakness);
        if (!canDefeat) return;
        
        IsDefeated = true;
        _tween = Renderer.DOColor(Color.clear, 2f);
        _tween.OnComplete(HandleHide);
    }

    private void HandleHide() {
        gameObject.SetActive(false);
        AudioController.Instance.Play(SuccessClip);
        OnDefeated?.Invoke(this);
    }
}
