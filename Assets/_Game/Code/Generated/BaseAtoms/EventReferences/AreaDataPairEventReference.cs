using System;
using Liver;

namespace UnityAtoms
{
    /// <summary>
    /// Event Reference of type `AreaDataPair`. Inherits from `AtomEventReference&lt;AreaDataPair, AreaDataVariable, AreaDataPairEvent, AreaDataVariableInstancer, AreaDataPairEventInstancer&gt;`.
    /// </summary>
    [Serializable]
    public sealed class AreaDataPairEventReference : AtomEventReference<
        AreaDataPair,
        AreaDataVariable,
        AreaDataPairEvent,
        AreaDataVariableInstancer,
        AreaDataPairEventInstancer>, IGetEvent 
    { }
}
