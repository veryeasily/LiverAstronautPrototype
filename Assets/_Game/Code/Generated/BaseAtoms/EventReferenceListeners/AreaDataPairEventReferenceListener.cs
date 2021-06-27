using UnityEngine;
using Liver;

namespace UnityAtoms
{
    /// <summary>
    /// Event Reference Listener of type `AreaDataPair`. Inherits from `AtomEventReferenceListener&lt;AreaDataPair, AreaDataPairEvent, AreaDataPairEventReference, AreaDataPairUnityEvent&gt;`.
    /// </summary>
    [EditorIcon("atom-icon-orange")]
    [AddComponentMenu("Unity Atoms/Listeners/AreaDataPair Event Reference Listener")]
    public sealed class AreaDataPairEventReferenceListener : AtomEventReferenceListener<
        AreaDataPair,
        AreaDataPairEvent,
        AreaDataPairEventReference,
        AreaDataPairUnityEvent>
    { }
}
