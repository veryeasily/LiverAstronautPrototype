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

    public PlayerController player;
    public InventoryController inventory;
    public List<EnemyBehaviour> enemies;

    public Image dialoguePortrait;
    public DialogueRunner dialogueRunner;

    private GameConfig _gameConfig;
    private readonly List<Npc> _visitedNpcs = new List<Npc>();
    [SerializeReference] private EnemyBehaviour _currentEnemy;

    public void Awake() {
        if (_instance != null && _instance != this) {
            throw new Exception("Tried to create multiple instances");
        }

        _instance = this;
    }

    public void Start() {
        _gameConfig = GameController.Instance.gameConfig;
    }

    public void Update() {
        CheckEnemies();
    }

    public void Add(EnemyBehaviour enemy) {
        enemies.Add(enemy);
    }

    public void Remove(EnemyBehaviour enemy) {
        enemies = enemies.FindAll(e => e != enemy);
    }

    private void CheckEnemies() {
        if (_currentEnemy) return;
        
        var activeEnemies = GetActiveEnemies();
        foreach (var enemy in activeEnemies) {
            var inRange = enemy.CheckDistance(player, _gameConfig.dialogueDistance);
            if (!inRange) continue;

            ActivateForEnemy(enemy);
            break;
        }
    }

    private void ActivateForEnemy(EnemyBehaviour enemy) {
        Debug.Log($"ENEMY ACTIVATED {enemy.characterName}");
        _currentEnemy = enemy;
        var canDefeat = inventory.Has(enemy.weakness);
        Debug.Log($"PlayerCanDefeat={canDefeat}");
    }

    private IEnumerable<EnemyBehaviour> GetActiveEnemies() {
        return enemies;
    }
}