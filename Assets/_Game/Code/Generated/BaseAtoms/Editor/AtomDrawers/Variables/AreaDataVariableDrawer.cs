#if UNITY_2019_1_OR_NEWER
using UnityEditor;
using UnityAtoms.Editor;

namespace UnityAtoms.Editor
{
    /// <summary>
    /// Variable property drawer of type `AreaData`. Inherits from `AtomDrawer&lt;AreaDataVariable&gt;`. Only availble in `UNITY_2019_1_OR_NEWER`.
    /// </summary>
    [CustomPropertyDrawer(typeof(AreaDataVariable))]
    public class AreaDataVariableDrawer : VariableDrawer<AreaDataVariable> { }
}
#endif
