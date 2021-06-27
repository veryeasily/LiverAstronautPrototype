using UnityEditor;
using UnityAtoms.Editor;

namespace UnityAtoms.Editor
{
    /// <summary>
    /// Variable Inspector of type `Specter`. Inherits from `AtomVariableEditor`
    /// </summary>
    [CustomEditor(typeof(SpecterVariable))]
    public sealed class SpecterVariableEditor : AtomVariableEditor<Specter, SpecterPair> { }
}
