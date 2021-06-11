using System;
using DG.Tweening;
using UnityEngine;
using Sirenix.OdinInspector;

public class EnemyBehaviour : SerializedMonoBehaviour {
    public bool IsDefeated;
    public NpcBehaviour weakness;
    public Sprite sprite;
    public YarnProgram dialogue;
    public string characterName;
    public SpriteRenderer Renderer;
    public event Action<EnemyBehaviour> OnDefeated;

    private Tween _tween;

    public void Awake() {
        GameState.Instance.Enemies.Add(this);
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

    public void Defeat() {
        IsDefeated = true;
        _tween = Renderer.DOColor(Color.clear, 2f);
        _tween.OnComplete(HandleHide);
    }

    private void HandleHide() {
        gameObject.SetActive(false);
        OnDefeated?.Invoke(this);
    }
}
