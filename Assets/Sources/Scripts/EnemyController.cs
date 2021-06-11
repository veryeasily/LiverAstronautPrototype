using System;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using Yarn.Unity;

public class EnemyController : SerializedMonoBehaviour {
    public static EnemyController Instance => _instance;
    private static EnemyController _instance;

    public PlayerController Player;

    public Image DialoguePortrait;
    public DialogueRunner DialogueRunner;

    [SerializeReference] private EnemyBehaviour _currentEnemy;

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
        if (_currentEnemy) return;
        
        var activeEnemies = GetActiveEnemies();
        foreach (var enemy in activeEnemies) {
            var maxDistance = GameState.Instance.GameConfig.DialogueDistance;
            var inRange = enemy.CheckDistance(Player, maxDistance);
            if (!inRange) continue;

            ActivateForEnemy(enemy);
            break;
        }
    }

    private void ActivateForEnemy(EnemyBehaviour enemy) {
        _currentEnemy = enemy;
        
        var canDefeat = GameState.Instance.Inventory.Contains(enemy.weakness);
        if (canDefeat) {
            enemy.Defeat();
        }
    }

    private IEnumerable<EnemyBehaviour> GetActiveEnemies() {
        return GameState.Instance.Enemies.FindAll(e => !e.IsDefeated);
    }
}