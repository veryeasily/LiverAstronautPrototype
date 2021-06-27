using UnityEngine;

namespace UnityAtoms
{
    /// <summary>
    /// Value List of type `Specter`. Inherits from `AtomValueList&lt;Specter, SpecterEvent&gt;`.
    /// </summary>
    [EditorIcon("atom-icon-piglet")]
    [CreateAssetMenu(menuName = "Unity Atoms/Value Lists/Specter", fileName = "SpecterValueList")]
    public sealed class SpecterValueList : AtomValueList<Specter, SpecterEvent> { }
}
