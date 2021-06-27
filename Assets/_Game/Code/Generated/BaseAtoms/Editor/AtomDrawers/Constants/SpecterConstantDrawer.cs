#if UNITY_2019_1_OR_NEWER
using UnityEditor;
using UnityAtoms.Editor;

namespace UnityAtoms.Editor
{
    /// <summary>
    /// Constant property drawer of type `Specter`. Inherits from `AtomDrawer&lt;SpecterConstant&gt;`. Only availble in `UNITY_2019_1_OR_NEWER`.
    /// </summary>
    [CustomPropertyDrawer(typeof(SpecterConstant))]
    public class SpecterConstantDrawer : VariableDrawer<SpecterConstant> { }
}
#endif
