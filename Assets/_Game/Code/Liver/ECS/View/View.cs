using Entitas;
using Entitas.Unity;
using Sirenix.OdinInspector;
using UnityEngine;

public class View : SerializedMonoBehaviour, IView, IPositionListener, IDestroyedListener {
    public virtual void Link(IEntity entity) {
        gameObject.Link(entity);
        var e = (GameEntity) entity;
        e.AddPositionListener(this);
        e.AddDestroyedListener(this);

        var pos = e.position.value;
        transform.localPosition = new Vector3(pos.x, pos.y);
    }

    public virtual void OnPosition(GameEntity entity, Vector2 value) {
        transform.localPosition = new Vector3(value.x, value.y);
    }

    public virtual void OnDestroyed(GameEntity entity) {
        destroy();
    }

    protected virtual void destroy() {
        var o = gameObject;
        o.Unlink();
        Destroy(o);
    }
}