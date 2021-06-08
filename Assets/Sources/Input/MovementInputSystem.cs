using Entitas;
using UnityEngine;

public sealed class MovementInputSystem : IExecuteSystem {
    private Contexts _contexts;
    private readonly IGroup<GameEntity> _playerGroup;
    private readonly IGroup<InputEntity> _inputGroup;
    
    public MovementInputSystem(Contexts contexts) {
        _contexts = contexts;
        _playerGroup = _contexts.game.GetGroup(GameMatcher.Player);
        _inputGroup = _contexts.input.GetGroup(InputMatcher.MovementInput);
    }

    public void Execute() {
        var entities = _inputGroup.GetEntities();
        var player = _playerGroup.GetSingleEntity();
        
        foreach (var entity in entities) {
            var vec = entity.movementInput.value;
            var view = player.view.value;
            var position = player.gridPosition.value;
            var parentView = view.transform.parent.GetComponent<Grid>();
            var inputVec = new Vector3Int((int)vec.x, (int)vec.y, 0);
            var cell = parentView.LocalToCell(position + inputVec);
            player.ReplaceGridPosition(cell);
            entity.Destroy();
        }
    }
}