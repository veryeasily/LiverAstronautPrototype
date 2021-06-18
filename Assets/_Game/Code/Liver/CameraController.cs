using UnityEngine;
using Sirenix.OdinInspector;

public class CameraController : SerializedMonoBehaviour {
    public PlayerController Player;
    
    private PositionBehaviour _cameraPosition;

    public void OnEnable() {
        Player.OnPlayerMoveEnd += HandleMoveFinished;
    }

    public void OnDisable() {
        Player.OnPlayerMoveEnd -= HandleMoveFinished;
    }

    public void Awake() {
        _cameraPosition = GetComponent<PositionBehaviour>();
    }

    private void HandleMoveFinished(PositionBehaviour position) {
        var vec = position.gameObject.transform.position;
        var result = (int) Mathf.Floor(vec.x / 16);
        _cameraPosition.Target.x = result * 16 + 8;
    }
}