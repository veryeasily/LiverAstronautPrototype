using Sirenix.OdinInspector;
using UnityEngine;

[CreateAssetMenu(menuName = "Liver/GameConfig", fileName = "NewGameConfig")]
public class GameConfig : SerializedScriptableObject {
    public float enemyDistance = 2f;
    public float dialogueDistance = 2f;
}