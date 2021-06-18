using Entitas;
using Entitas.Unity;
using Sirenix.OdinInspector;
using UnityEngine;

public class ViewController : SerializedMonoBehaviour {
    private Context<GameEntity> _context;
    
    public void Start() {
        _context = Contexts.sharedInstance.game;
        
        var views = FindObjectsOfType<View>();
        foreach (var view in views) {
            var link = view.gameObject.GetEntityLink();
            if (link != null) continue;

            var entity = _context.CreateEntity();
            entity.AddPosition(Vector2.zero);
            view.Link(entity);
            entity.AddView(view);
        }
    }
}