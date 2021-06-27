#if UNITY_2019_1_OR_NEWER
using UnityEditor;
using UnityAtoms.Editor;

namespace UnityAtoms.Editor
{
    /// <summary>
    /// Value List property drawer of type `Specter`. Inherits from `AtomDrawer&lt;SpecterValueList&gt;`. Only availble in `UNITY_2019_1_OR_NEWER`.
    /// </summary>
    [CustomPropertyDrawer(typeof(SpecterValueList))]
    public class SpecterValueListDrawer : AtomDrawer<SpecterValueList> { }
}
#endif
