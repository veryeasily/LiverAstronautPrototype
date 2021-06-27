using UnityEngine;
using UnityAtoms.BaseAtoms;
using Liver;

namespace UnityAtoms
{
    /// <summary>
    /// Variable Instancer of type `AreaData`. Inherits from `AtomVariableInstancer&lt;AreaDataVariable, AreaDataPair, AreaData, AreaDataEvent, AreaDataPairEvent, AreaDataAreaDataFunction&gt;`.
    /// </summary>
    [EditorIcon("atom-icon-hotpink")]
    [AddComponentMenu("Unity Atoms/Variable Instancers/AreaData Variable Instancer")]
    public class AreaDataVariableInstancer : AtomVariableInstancer<
        AreaDataVariable,
        AreaDataPair,
        AreaData,
        AreaDataEvent,
        AreaDataPairEvent,
        AreaDataAreaDataFunction>
    { }
}
