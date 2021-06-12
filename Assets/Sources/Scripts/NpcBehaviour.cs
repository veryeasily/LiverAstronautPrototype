using UnityEngine;
using Sirenix.OdinInspector;

public class NpcBehaviour : SerializedMonoBehaviour {
    public bool WasVisited;
    public Sprite sprite;
    public YarnProgram dialogue;
    public string characterName;
    public Color Color = Color.blue;

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