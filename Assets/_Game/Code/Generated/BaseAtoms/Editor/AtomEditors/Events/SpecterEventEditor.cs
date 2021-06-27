#if UNITY_2019_1_OR_NEWER
using UnityEditor;
using UnityEngine.UIElements;
using UnityAtoms.Editor;

namespace UnityAtoms.Editor
{
    /// <summary>
    /// Event property drawer of type `Specter`. Inherits from `AtomEventEditor&lt;Specter, SpecterEvent&gt;`. Only availble in `UNITY_2019_1_OR_NEWER`.
    /// </summary>
    [CustomEditor(typeof(SpecterEvent))]
    public sealed class SpecterEventEditor : AtomEventEditor<Specter, SpecterEvent> { }
}
#endif
