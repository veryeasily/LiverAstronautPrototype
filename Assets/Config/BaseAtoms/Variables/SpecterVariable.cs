using UnityEngine;

namespace UnityAtoms
{
    /// <summary>
    /// Variable of type `Specter`. Inherits from `EquatableAtomVariable&lt;Specter, SpecterPair, SpecterEvent, SpecterPairEvent, SpecterSpecterFunction&gt;`.
    /// </summary>
    [EditorIcon("atom-icon-lush")]
    [CreateAssetMenu(menuName = "Unity Atoms/Variables/Specter", fileName = "SpecterVariable")]
    public sealed class SpecterVariable : EquatableAtomVariable<Specter, SpecterPair, SpecterEvent, SpecterPairEvent, SpecterSpecterFunction>
    {
    }
}
