using System;
using Liver;

namespace UnityAtoms
{
    /// <summary>
    /// Event Reference of type `AreaData`. Inherits from `AtomEventReference&lt;AreaData, AreaDataVariable, AreaDataEvent, AreaDataVariableInstancer, AreaDataEventInstancer&gt;`.
    /// </summary>
    [Serializable]
    public sealed class AreaDataEventReference : AtomEventReference<
        AreaData,
        AreaDataVariable,
        AreaDataEvent,
        AreaDataVariableInstancer,
        AreaDataEventInstancer>, IGetEvent 
    { }
}
