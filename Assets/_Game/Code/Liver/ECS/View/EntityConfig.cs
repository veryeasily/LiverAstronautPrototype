using Entitas;
using Sirenix.OdinInspector;
using UnityEngine;

[CreateAssetMenu(menuName = "Liver/EntityConfig")]
public class EntityConfig : SerializedScriptableObject {
    public IComponent[] components;
}