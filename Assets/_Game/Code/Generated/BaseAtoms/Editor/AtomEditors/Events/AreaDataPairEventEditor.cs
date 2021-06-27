#if UNITY_2019_1_OR_NEWER
using UnityEditor;
using UnityEngine.UIElements;
using UnityAtoms.Editor;
using Liver;

namespace UnityAtoms.Editor
{
    /// <summary>
    /// Event property drawer of type `AreaDataPair`. Inherits from `AtomEventEditor&lt;AreaDataPair, AreaDataPairEvent&gt;`. Only availble in `UNITY_2019_1_OR_NEWER`.
    /// </summary>
    [CustomEditor(typeof(AreaDataPairEvent))]
    public sealed class AreaDataPairEventEditor : AtomEventEditor<AreaDataPair, AreaDataPairEvent> { }
}
#endif
