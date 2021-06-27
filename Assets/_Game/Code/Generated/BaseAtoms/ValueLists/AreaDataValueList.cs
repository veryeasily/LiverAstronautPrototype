using UnityEngine;
using Liver;

namespace UnityAtoms
{
    /// <summary>
    /// Value List of type `AreaData`. Inherits from `AtomValueList&lt;AreaData, AreaDataEvent&gt;`.
    /// </summary>
    [EditorIcon("atom-icon-piglet")]
    [CreateAssetMenu(menuName = "Unity Atoms/Value Lists/AreaData", fileName = "AreaDataValueList")]
    public sealed class AreaDataValueList : AtomValueList<AreaData, AreaDataEvent> { }
}
