#if UNITY_2019_1_OR_NEWER
using UnityEditor;
using UnityEngine.UIElements;
using UnityAtoms.Editor;
using Liver;

namespace UnityAtoms.Editor
{
    /// <summary>
    /// Event property drawer of type `AreaData`. Inherits from `AtomEventEditor&lt;AreaData, AreaDataEvent&gt;`. Only availble in `UNITY_2019_1_OR_NEWER`.
    /// </summary>
    [CustomEditor(typeof(AreaDataEvent))]
    public sealed class AreaDataEventEditor : AtomEventEditor<AreaData, AreaDataEvent> { }
}
#endif
