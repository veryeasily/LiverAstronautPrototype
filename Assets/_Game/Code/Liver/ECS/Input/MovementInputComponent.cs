using Entitas;
using UnityEngine;
using UnityEngine.InputSystem;

[Input]
public sealed class MovementInputComponent : IComponent {
    public Vector2 value;
}