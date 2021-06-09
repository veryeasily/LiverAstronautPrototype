using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

public class PositionController : SerializedMonoBehaviour {
    public static PositionController Instance;
    
    private readonly List<PositionBehaviour> _positionBehaviours = new List<PositionBehaviour>();

    public void Awake() {
        Instance = this;
    }

    public void Update() {
        foreach (var position in _positionBehaviours) {
            var positionObject = position.gameObject;
            var current = positionObject.transform.position;
            var target = position.Target;
            var speed = position.Speed;
            var next = Vector3.MoveTowards(current, target, speed * Time.deltaTime);
            positionObject.transform.position = next;
            var prevFinished = position.IsFinished;
            position.IsFinished = next == target;
            if (position.IsFinished && prevFinished != position.IsFinished) {
                position.MoveComplete();
            }
        }
    }

    public void AddPosition(PositionBehaviour position) {
        _positionBehaviours.Add(position);
    }
}