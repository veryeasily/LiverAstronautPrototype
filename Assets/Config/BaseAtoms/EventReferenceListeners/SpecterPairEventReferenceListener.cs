using UnityEngine;

namespace UnityAtoms
{
    /// <summary>
    /// Event Reference Listener of type `SpecterPair`. Inherits from `AtomEventReferenceListener&lt;SpecterPair, SpecterPairEvent, SpecterPairEventReference, SpecterPairUnityEvent&gt;`.
    /// </summary>
    [EditorIcon("atom-icon-orange")]
    [AddComponentMenu("Unity Atoms/Listeners/SpecterPair Event Reference Listener")]
    public sealed class SpecterPairEventReferenceListener : AtomEventReferenceListener<
        SpecterPair,
        SpecterPairEvent,
        SpecterPairEventReference,
        SpecterPairUnityEvent>
    { }
}
