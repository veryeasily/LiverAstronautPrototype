using Entitas;

public sealed class AnimateMovementSystem : IExecuteSystem {
    private Contexts _contexts;
    private IGroup<GameEntity> _group;
    
    public AnimateMovementSystem(Contexts contexts) {
        _contexts = contexts;
        _group = _contexts.game.GetGroup(GameMatcher.AnimateGrid);
    }

    public void Execute() {
        var entities = _group.GetEntities();
        foreach (var e in entities) {
            var position = e.position.value;
        }
    }
}