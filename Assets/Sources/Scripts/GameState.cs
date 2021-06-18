using System;
using UniRx;
using Sirenix.OdinInspector;
using System.Collections.Generic;
using UnityAtoms;

public class GameState : SerializedMonoBehaviour {
    public static GameState Instance => _instance;
    private static GameState _instance;

    public GameConfig GameConfig;
    public bool IsDialoguePlaying;
    public PlayerController Player;

    public List<SpeakerBehaviour> Npcs = new List<SpeakerBehaviour>();
    public List<ObstacleBehaviour> Obstacles = new List<ObstacleBehaviour>();

    public ReactiveProperty<Specter> FailedItem = new ReactiveProperty<Specter>();

    public event Action OnDialogueEnd;
    public event Action OnDialogueStart;
    
    public void Awake() {
        if (_instance != null && _instance != this) {
            throw new Exception("Tried to create multiple instances");
        }

        _instance = this;
    }

    public void TriggerDialogueStart() {
        OnDialogueStart?.Invoke();
    }

    public void TriggerDialogueEnd() {
        OnDialogueEnd?.Invoke();
    }
}