using System;
using Cysharp.Threading.Tasks;
using Sirenix.OdinInspector;
using UnityEngine;

public class GameController : SerializedMonoBehaviour {
    public static GameController Instance => _instance;
    private static GameController _instance;

    public GameObject YouWinObject;

    public void Awake() {
        if (_instance != null && _instance != this) {
            throw new Exception("Tried to create multiple instances");
        }

        _instance = this;
    }

    public async void WinGame() {
        YouWinObject.SetActive(true);
        await UniTask.Delay(TimeSpan.FromSeconds(10f));
        Application.Quit();
    }
}