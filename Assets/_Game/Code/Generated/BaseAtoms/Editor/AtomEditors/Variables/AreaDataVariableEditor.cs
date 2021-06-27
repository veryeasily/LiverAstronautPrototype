using UnityEditor;
using UnityAtoms.Editor;
using Liver;

namespace UnityAtoms.Editor
{
    /// <summary>
    /// Variable Inspector of type `AreaData`. Inherits from `AtomVariableEditor`
    /// </summary>
    [CustomEditor(typeof(AreaDataVariable))]
    public sealed class AreaDataVariableEditor : AtomVariableEditor<AreaData, AreaDataPair> { }
}
