#if UNITY_2019_1_OR_NEWER
using UnityEditor;
using UnityAtoms.Editor;

namespace UnityAtoms.Editor
{
    /// <summary>
    /// Variable property drawer of type `Specter`. Inherits from `AtomDrawer&lt;SpecterVariable&gt;`. Only availble in `UNITY_2019_1_OR_NEWER`.
    /// </summary>
    [CustomPropertyDrawer(typeof(SpecterVariable))]
    public class SpecterVariableDrawer : VariableDrawer<SpecterVariable> { }
}
#endif
