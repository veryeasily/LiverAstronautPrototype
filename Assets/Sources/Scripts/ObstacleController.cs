using System;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using System.Linq;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;
using Yarn.Unity;

public class ObstacleController : SerializedMonoBehaviour {
    public static ObstacleController Instance => _instance;
    private static ObstacleController _instance;

    public PlayerController Player;

    public Image DialoguePortrait;
    public DialogueRunner DialogueRunner;

    [FormerlySerializedAs("_currentEnemy")] [SerializeReference] private ObstacleBehaviour CurrentObstacle;

    public void Awake() {
        if (_instance != null && _instance != this) {
            throw new Exception("Tried to create multiple instances");
        }

        _instance = this;
    }

    public void OnEnable() {
        Player.OnPlayerMoveEnd += HandlePlayerMoveEnd;
    }

    public void OnDisable() {
        Player.OnPlayerMoveEnd -= HandlePlayerMoveEnd;
    }

    private void HandlePlayerMoveEnd(object ignore) {
        CheckEnemies();
    }

    private void CheckEnemies() {
        if (CurrentObstacle) return;
        
        var activeEnemies = GetActiveEnemies();
        foreach (var enemy in activeEnemies) {
            var maxDistance = GameState.Instance.GameConfig.DialogueDistance;
            var inRange = enemy.CheckDistance(Player, maxDistance);
            if (!inRange) continue;

            ActivateForEnemy(enemy);
            break;
        }
    }

    private void ActivateForEnemy(ObstacleBehaviour obstacle) {
        CurrentObstacle = obstacle;
        
        var canDefeat = GameState.Instance.Inventory.Contains(obstacle.weakness);
        if (canDefeat) {
            obstacle.Defeat();
        }
    }

    private IEnumerable<ObstacleBehaviour> GetActiveEnemies() {
        return GameState.Instance.Enemies.FindAll(e => !e.IsDefeated);
    }
}