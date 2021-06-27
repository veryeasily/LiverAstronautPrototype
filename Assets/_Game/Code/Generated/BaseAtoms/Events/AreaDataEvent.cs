using UnityEngine;
using Liver;

namespace UnityAtoms
{
    /// <summary>
    /// Event of type `AreaData`. Inherits from `AtomEvent&lt;AreaData&gt;`.
    /// </summary>
    [EditorIcon("atom-icon-cherry")]
    [CreateAssetMenu(menuName = "Unity Atoms/Events/AreaData", fileName = "AreaDataEvent")]
    public sealed class AreaDataEvent : AtomEvent<AreaData>
    {
    }
}
