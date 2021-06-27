using UnityEngine;
using Liver;

namespace UnityAtoms
{
    /// <summary>
    /// Event Reference Listener of type `AreaData`. Inherits from `AtomEventReferenceListener&lt;AreaData, AreaDataEvent, AreaDataEventReference, AreaDataUnityEvent&gt;`.
    /// </summary>
    [EditorIcon("atom-icon-orange")]
    [AddComponentMenu("Unity Atoms/Listeners/AreaData Event Reference Listener")]
    public sealed class AreaDataEventReferenceListener : AtomEventReferenceListener<
        AreaData,
        AreaDataEvent,
        AreaDataEventReference,
        AreaDataUnityEvent>
    { }
}
