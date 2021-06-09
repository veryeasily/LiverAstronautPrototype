using UnityEngine;
using Sirenix.OdinInspector;

public class Npc : SerializedMonoBehaviour {
    public Sprite sprite;
    public YarnProgram dialogue;
    public string characterName;

    public bool CheckDistance(PlayerController player, float maxDistance) {
        var position = transform.position;
        var playerPosition = player.transform.position;
        var distance = Vector3.SqrMagnitude(position - playerPosition);
        return distance <= maxDistance;
    }
}