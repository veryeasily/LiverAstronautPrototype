#if UNITY_2019_1_OR_NEWER
using UnityEditor;
using UnityAtoms.Editor;

namespace UnityAtoms.Editor
{
    /// <summary>
    /// Constant property drawer of type `AreaData`. Inherits from `AtomDrawer&lt;AreaDataConstant&gt;`. Only availble in `UNITY_2019_1_OR_NEWER`.
    /// </summary>
    [CustomPropertyDrawer(typeof(AreaDataConstant))]
    public class AreaDataConstantDrawer : VariableDrawer<AreaDataConstant> { }
}
#endif
