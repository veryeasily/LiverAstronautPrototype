using UnityEngine;
using Liver;

namespace UnityAtoms
{
    /// <summary>
    /// Event of type `AreaDataPair`. Inherits from `AtomEvent&lt;AreaDataPair&gt;`.
    /// </summary>
    [EditorIcon("atom-icon-cherry")]
    [CreateAssetMenu(menuName = "Unity Atoms/Events/AreaDataPair", fileName = "AreaDataPairEvent")]
    public sealed class AreaDataPairEvent : AtomEvent<AreaDataPair>
    {
    }
}
