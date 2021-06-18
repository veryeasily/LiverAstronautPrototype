using UnityEngine;
using UnityAtoms.BaseAtoms;

namespace UnityAtoms
{
    /// <summary>
    /// Set variable value Action of type `Specter`. Inherits from `SetVariableValue&lt;Specter, SpecterPair, SpecterVariable, SpecterConstant, SpecterReference, SpecterEvent, SpecterPairEvent, SpecterVariableInstancer&gt;`.
    /// </summary>
    [EditorIcon("atom-icon-purple")]
    [CreateAssetMenu(menuName = "Unity Atoms/Actions/Set Variable Value/Specter", fileName = "SetSpecterVariableValue")]
    public sealed class SetSpecterVariableValue : SetVariableValue<
        Specter,
        SpecterPair,
        SpecterVariable,
        SpecterConstant,
        SpecterReference,
        SpecterEvent,
        SpecterPairEvent,
        SpecterSpecterFunction,
        SpecterVariableInstancer>
    { }
}
