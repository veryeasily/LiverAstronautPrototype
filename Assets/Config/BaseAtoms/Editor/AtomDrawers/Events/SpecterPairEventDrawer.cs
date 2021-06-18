#if UNITY_2019_1_OR_NEWER
using UnityEditor;
using UnityAtoms.Editor;

namespace UnityAtoms.Editor
{
    /// <summary>
    /// Event property drawer of type `SpecterPair`. Inherits from `AtomDrawer&lt;SpecterPairEvent&gt;`. Only availble in `UNITY_2019_1_OR_NEWER`.
    /// </summary>
    [CustomPropertyDrawer(typeof(SpecterPairEvent))]
    public class SpecterPairEventDrawer : AtomDrawer<SpecterPairEvent> { }
}
#endif
