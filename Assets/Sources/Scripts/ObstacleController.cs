using System;
using System.Collections.Generic;

public class ObstacleController : LiverBehaviour {
    public static ObstacleController Instance => _instance;
    private static ObstacleController _instance;

    public PlayerController Player;
    private GameState _state => GameState.Instance;

    private static IEnumerable<ObstacleBehaviour> GetActiveObstacles() {
        return GameState.Instance.Obstacles.FindAll(e => !e.IsDefeated);
    }

    public void Awake() {
        if (_instance != null && _instance != this) {
            throw new Exception("Tried to create multiple instances");
        }

        _instance = this;
    }

    public override void StartOrEnable() {
        Player.OnPlayerMoveEnd += HandlePlayerMoveEnd;
    }

    public void OnDisable() {
        Player.OnPlayerMoveEnd -= HandlePlayerMoveEnd;
    }

    public void CheckObstacles() {
        _state.FailedItem.Value = null;
        var activeObstacles = GetActiveObstacles();
        foreach (var obstacle in activeObstacles) {
            var maxDistance = _state.GameConfig.DialogueDistance;
            var inRange = obstacle.CheckDistance(Player, maxDistance);
            if (!inRange) continue;

            if (!obstacle.AttemptSuccess()) {
                _state.FailedItem.Value = obstacle.weakness;
            }

            break;
        }
    }

    private void HandlePlayerMoveEnd(object ignore) {
        CheckObstacles();
    }
}