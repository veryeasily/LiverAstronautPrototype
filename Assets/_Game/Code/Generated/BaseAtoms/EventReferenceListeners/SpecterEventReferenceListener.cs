using UnityEngine;

namespace UnityAtoms
{
    /// <summary>
    /// Event Reference Listener of type `Specter`. Inherits from `AtomEventReferenceListener&lt;Specter, SpecterEvent, SpecterEventReference, SpecterUnityEvent&gt;`.
    /// </summary>
    [EditorIcon("atom-icon-orange")]
    [AddComponentMenu("Unity Atoms/Listeners/Specter Event Reference Listener")]
    public sealed class SpecterEventReferenceListener : AtomEventReferenceListener<
        Specter,
        SpecterEvent,
        SpecterEventReference,
        SpecterUnityEvent>
    { }
}
