using System;
using UnityEngine;
using Sirenix.OdinInspector;

public class EnemyBehaviour : SerializedMonoBehaviour {
    public Npc weakness;
    public Sprite sprite;
    public YarnProgram dialogue;
    public string characterName;

    public void OnEnable() {
        EnemyController.Instance.Add(this);
    }

    public void OnDisable() {
        EnemyController.Instance.Remove(this);
    }

    public bool CheckDistance(PlayerController player, float maxDistance) {
        var position = transform.position;
        var playerPosition = player.transform.position;
        var distance = Vector3.SqrMagnitude(position - playerPosition);
        return distance <= maxDistance;
    }
}
