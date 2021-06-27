using UnityEngine;
using Liver;

namespace UnityAtoms
{
    /// <summary>
    /// Event Instancer of type `AreaData`. Inherits from `AtomEventInstancer&lt;AreaData, AreaDataEvent&gt;`.
    /// </summary>
    [EditorIcon("atom-icon-sign-blue")]
    [AddComponentMenu("Unity Atoms/Event Instancers/AreaData Event Instancer")]
    public class AreaDataEventInstancer : AtomEventInstancer<AreaData, AreaDataEvent> { }
}
