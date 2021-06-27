#if UNITY_2019_1_OR_NEWER
using UnityEditor;
using UnityAtoms.Editor;

namespace UnityAtoms.Editor
{
    /// <summary>
    /// Event property drawer of type `AreaDataPair`. Inherits from `AtomDrawer&lt;AreaDataPairEvent&gt;`. Only availble in `UNITY_2019_1_OR_NEWER`.
    /// </summary>
    [CustomPropertyDrawer(typeof(AreaDataPairEvent))]
    public class AreaDataPairEventDrawer : AtomDrawer<AreaDataPairEvent> { }
}
#endif
