using System;
using UnityEngine;
using UniRx;

[RequireComponent(typeof(Animator))]
public class ThoughtBalloon : LiverBehaviour {
    public SpriteRenderer IdeaRenderer;

    private Animator _animator;
    private IDisposable _failedObserver;
    private GameState _state => GameState.Instance;

    public void OnDisable() {
        _failedObserver.Dispose();
    }

    public override void StartOrEnable() {
        _animator = GetComponent<Animator>();
        Render();
        _failedObserver = _state.FailedItem.Subscribe(_ => Render());
    }

    private void Render() {
        var failedItem = _state.FailedItem.Value;
        IdeaRenderer.sprite = failedItem ? failedItem.Sprite : null;
        _animator.SetInteger("Status", failedItem ? 1 : 0);
    }
}