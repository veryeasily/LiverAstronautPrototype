#if UNITY_2019_1_OR_NEWER
using UnityEditor;
using UnityAtoms.Editor;

namespace UnityAtoms.Editor
{
    /// <summary>
    /// Event property drawer of type `AreaData`. Inherits from `AtomDrawer&lt;AreaDataEvent&gt;`. Only availble in `UNITY_2019_1_OR_NEWER`.
    /// </summary>
    [CustomPropertyDrawer(typeof(AreaDataEvent))]
    public class AreaDataEventDrawer : AtomDrawer<AreaDataEvent> { }
}
#endif
