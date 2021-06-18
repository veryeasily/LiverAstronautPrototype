using Sirenix.OdinInspector;
using UnityEngine;

[CreateAssetMenu(menuName = "Liver/GameSettings", fileName = "NewGameSettings")]
public class GameSettings : SerializedScriptableObject {
    public static GameSettings Instance { get; private set; }

    public float EnemyDistance = 2f;
    public float DialogueDistance = 2f;

    public static void SetConfig(GameSettings settings) {
        Instance = settings;
    }
}