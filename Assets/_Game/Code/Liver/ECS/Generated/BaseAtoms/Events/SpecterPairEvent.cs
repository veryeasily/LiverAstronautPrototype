using UnityEngine;

namespace UnityAtoms
{
    /// <summary>
    /// Event of type `SpecterPair`. Inherits from `AtomEvent&lt;SpecterPair&gt;`.
    /// </summary>
    [EditorIcon("atom-icon-cherry")]
    [CreateAssetMenu(menuName = "Unity Atoms/Events/SpecterPair", fileName = "SpecterPairEvent")]
    public sealed class SpecterPairEvent : AtomEvent<SpecterPair>
    {
    }
}
