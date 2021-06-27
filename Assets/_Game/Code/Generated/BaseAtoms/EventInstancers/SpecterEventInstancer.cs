using UnityEngine;

namespace UnityAtoms
{
    /// <summary>
    /// Event Instancer of type `Specter`. Inherits from `AtomEventInstancer&lt;Specter, SpecterEvent&gt;`.
    /// </summary>
    [EditorIcon("atom-icon-sign-blue")]
    [AddComponentMenu("Unity Atoms/Event Instancers/Specter Event Instancer")]
    public class SpecterEventInstancer : AtomEventInstancer<Specter, SpecterEvent> { }
}
