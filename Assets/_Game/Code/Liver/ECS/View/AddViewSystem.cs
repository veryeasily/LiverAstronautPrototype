using System.Collections.Generic;
using Entitas;
using UnityEngine;

public sealed class AddViewSystem : ReactiveSystem<GameEntity> {
    private readonly Transform _parent;

    public AddViewSystem(Contexts contexts) : base(contexts.game) {
        _parent = new GameObject("Views").transform;
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        => context.CreateCollector(GameMatcher.Asset);

    protected override bool Filter(GameEntity entity) => entity.hasAsset && !entity.hasView;

    protected override void Execute(List<GameEntity> entities) {
        foreach (var e in entities) {
            e.AddView(InstantiateView(e));
        }
    }

    private View InstantiateView(GameEntity entity) {
        var prefab = Resources.Load<GameObject>(entity.asset.value);
        var view = Object.Instantiate(prefab, _parent).GetComponent<View>();
        view.Link(entity);
        return view;
    }
}