using UnityEngine;
using Sirenix.OdinInspector;
using System.Collections.Generic;
using DG.Tweening;
using UniRx.Triggers;

public class PositionController : SerializedMonoBehaviour {
    public static PositionController Instance;
    
    private readonly List<PositionBehaviour> _positionBehaviours = new List<PositionBehaviour>();

    public void Awake() {
        Instance = this;
    }

    public void FixedUpdate() {
        foreach (var position in _positionBehaviours) {
            if (position.CurrentTween != null) continue;

            var posTrans = position.gameObject.transform;
            if (posTrans.position == position.Target) continue;
            
            var distance = Vector3.Distance(position.Target, posTrans.position);
            var time = distance / position.Speed;
            var tween = posTrans.DOMove(position.Target, time);
            tween.SetEase(Ease.Linear);
            tween.OnComplete(() => {
                position.MoveComplete();
            });
            position.IsFinished = false;
            position.CurrentTween = tween;
        }
    }

    public void AddPosition(PositionBehaviour position) {
        _positionBehaviours.Add(position);
    }
}