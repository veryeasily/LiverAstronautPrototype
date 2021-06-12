using DG.Tweening;
using Sirenix.OdinInspector;
using System.Collections.Generic;

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
            if (posTrans.localPosition == position.Target) continue;

            var time = position.GetTravelTime();
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