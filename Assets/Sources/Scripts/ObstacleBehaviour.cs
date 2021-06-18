using System;
using DG.Tweening;
using UnityEngine;
using Sirenix.OdinInspector;
using UnityAtoms;

public class ObstacleBehaviour : SerializedMonoBehaviour {
    public bool IsDefeated;
    public Specter weakness;
    public Sprite sprite;
    public YarnProgram dialogue;
    public string characterName;
    public AudioClip SuccessClip;
    public SpriteRenderer Renderer;
    public event Action<ObstacleBehaviour> OnDefeated;

    private Tween _tween;
    private GameState _state => GameState.Instance;
    [SerializeField, Required] private SpecterVariable _currentSpecter;

    public void Start() {
        _state.Obstacles.Add(this);
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

    public bool AttemptSuccess() {
        var selectedItem = _currentSpecter.Value;
        var canDefeat = weakness == selectedItem;
        if (!canDefeat) {
            return false;
        }
        
        IsDefeated = true;
        _tween = Renderer.DOColor(Color.clear, 2f);
        _tween.OnComplete(HandleHide);
        return true;
    }

    private void HandleHide() {
        gameObject.SetActive(false);
        AudioController.Instance.Play(SuccessClip);
        OnDefeated?.Invoke(this);
    }
}
