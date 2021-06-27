using UnityEngine;
using UnityAtoms.BaseAtoms;
using Liver;

namespace UnityAtoms
{
    /// <summary>
    /// Set variable value Action of type `AreaData`. Inherits from `SetVariableValue&lt;AreaData, AreaDataPair, AreaDataVariable, AreaDataConstant, AreaDataReference, AreaDataEvent, AreaDataPairEvent, AreaDataVariableInstancer&gt;`.
    /// </summary>
    [EditorIcon("atom-icon-purple")]
    [CreateAssetMenu(menuName = "Unity Atoms/Actions/Set Variable Value/AreaData", fileName = "SetAreaDataVariableValue")]
    public sealed class SetAreaDataVariableValue : SetVariableValue<
        AreaData,
        AreaDataPair,
        AreaDataVariable,
        AreaDataConstant,
        AreaDataReference,
        AreaDataEvent,
        AreaDataPairEvent,
        AreaDataAreaDataFunction,
        AreaDataVariableInstancer>
    { }
}
