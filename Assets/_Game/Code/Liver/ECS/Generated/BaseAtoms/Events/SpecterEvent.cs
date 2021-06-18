using UnityEngine;

namespace UnityAtoms
{
    /// <summary>
    /// Event of type `Specter`. Inherits from `AtomEvent&lt;Specter&gt;`.
    /// </summary>
    [EditorIcon("atom-icon-cherry")]
    [CreateAssetMenu(menuName = "Unity Atoms/Events/Specter", fileName = "SpecterEvent")]
    public sealed class SpecterEvent : AtomEvent<Specter>
    {
    }
}
