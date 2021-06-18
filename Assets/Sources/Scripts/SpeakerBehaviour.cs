using UnityEngine;
using Sirenix.OdinInspector;

public class SpeakerBehaviour : SerializedMonoBehaviour {
    public bool WasVisited;
    public Speaker NpcSpeaker;

    public void Awake() {
        GameState.Instance.Npcs.Add(this);
    }

    public bool CheckDistance(PlayerController player, float maxDistance) {
        var position = transform.position;
        var playerPosition = player.transform.position;
        var distance = Vector3.SqrMagnitude(position - playerPosition);
        return distance <= maxDistance;
    }
}