using UnityEngine;
using Liver;

namespace UnityAtoms
{
    /// <summary>
    /// Event Instancer of type `AreaDataPair`. Inherits from `AtomEventInstancer&lt;AreaDataPair, AreaDataPairEvent&gt;`.
    /// </summary>
    [EditorIcon("atom-icon-sign-blue")]
    [AddComponentMenu("Unity Atoms/Event Instancers/AreaDataPair Event Instancer")]
    public class AreaDataPairEventInstancer : AtomEventInstancer<AreaDataPair, AreaDataPairEvent> { }
}
