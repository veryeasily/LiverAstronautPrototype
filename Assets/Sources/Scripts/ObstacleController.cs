using System;
using System.Collections.Generic;
using Sirenix.OdinInspector;

public class ObstacleController : SerializedMonoBehaviour {
    public static ObstacleController Instance => _instance;
    private static ObstacleController _instance;

    public PlayerController Player;

    private static IEnumerable<ObstacleBehaviour> GetActiveObstacles() {
        return GameState.Instance.Obstacles.FindAll(e => !e.IsDefeated);
    }
    
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
        CheckObstacles();
    }

    private void CheckObstacles() {
        var activeObstacles = GetActiveObstacles();
        foreach (var obstacle in activeObstacles) {
            var maxDistance = GameState.Instance.GameConfig.DialogueDistance;
            var inRange = obstacle.CheckDistance(Player, maxDistance);
            if (!inRange) continue;

            obstacle.AttemptSuccess();
            break;
        }
    }
}