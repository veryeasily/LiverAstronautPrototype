using UnityEngine;
using Sirenix.OdinInspector;

public class NpcBehaviour : SerializedMonoBehaviour, IDialogue {
    public bool WasVisited;
    public Sprite Sprite;
    public YarnProgram Dialogue;
    public string CharacterName;
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

    public Sprite GetSprite() {
        return Sprite;
    }

    public YarnProgram GetDialogue() {
        return Dialogue;
    }
}