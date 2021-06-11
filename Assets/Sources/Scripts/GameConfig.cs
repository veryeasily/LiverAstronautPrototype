using Sirenix.OdinInspector;
using UnityEngine;

[CreateAssetMenu(menuName = "Liver/GameConfig", fileName = "NewGameConfig")]
public class GameConfig : SerializedScriptableObject {
    public static GameConfig Instance { get; private set; }

    public float EnemyDistance = 2f;
    public float DialogueDistance = 2f;

    public static void SetConfig(GameConfig config) {
        Instance = config;
    }
}