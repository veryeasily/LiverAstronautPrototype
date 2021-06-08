using Entitas;
using UnityEngine;

public class PlayerView : View {
    public override void Link(IEntity entity) {
        base.Link(entity);
        var e = (GameEntity) entity;
        e.isPlayer = true;
        e.AddGridPosition(GetCell());
    }

    private Vector3Int GetCell() {
        var t = transform;
        var grid = t.parent.GetComponent<Grid>();
        return grid.LocalToCell(t.position);
    }
}