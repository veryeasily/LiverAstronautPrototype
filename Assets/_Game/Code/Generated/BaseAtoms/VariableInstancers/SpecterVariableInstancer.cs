using UnityEngine;
using UnityAtoms.BaseAtoms;

namespace UnityAtoms
{
    /// <summary>
    /// Variable Instancer of type `Specter`. Inherits from `AtomVariableInstancer&lt;SpecterVariable, SpecterPair, Specter, SpecterEvent, SpecterPairEvent, SpecterSpecterFunction&gt;`.
    /// </summary>
    [EditorIcon("atom-icon-hotpink")]
    [AddComponentMenu("Unity Atoms/Variable Instancers/Specter Variable Instancer")]
    public class SpecterVariableInstancer : AtomVariableInstancer<
        SpecterVariable,
        SpecterPair,
        Specter,
        SpecterEvent,
        SpecterPairEvent,
        SpecterSpecterFunction>
    { }
}
