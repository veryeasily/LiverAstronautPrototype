using System;
using Entitas;

public static class ContextsIdExtensions {
    public static void SubscribeId(this Contexts contexts) {
        foreach (var context in contexts.allContexts) {
            if (Array.FindIndex(context.contextInfo.componentTypes, v => v == typeof(IdComponent)) >= 0) {
                context.OnEntityCreated += AddId;
            }
        }
    }

    private static void AddId(IContext context, IEntity entity) {
        var gameEntity = entity as GameEntity;
        gameEntity?.ReplaceId(gameEntity.creationIndex);
    }
}