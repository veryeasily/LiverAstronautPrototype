#if UNITY_2019_1_OR_NEWER
using UnityEditor;
using UnityAtoms.Editor;

namespace UnityAtoms.Editor
{
    /// <summary>
    /// Event property drawer of type `Specter`. Inherits from `AtomDrawer&lt;SpecterEvent&gt;`. Only availble in `UNITY_2019_1_OR_NEWER`.
    /// </summary>
    [CustomPropertyDrawer(typeof(SpecterEvent))]
    public class SpecterEventDrawer : AtomDrawer<SpecterEvent> { }
}
#endif
