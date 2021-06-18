using System;

namespace UnityAtoms
{
    /// <summary>
    /// Event Reference of type `SpecterPair`. Inherits from `AtomEventReference&lt;SpecterPair, SpecterVariable, SpecterPairEvent, SpecterVariableInstancer, SpecterPairEventInstancer&gt;`.
    /// </summary>
    [Serializable]
    public sealed class SpecterPairEventReference : AtomEventReference<
        SpecterPair,
        SpecterVariable,
        SpecterPairEvent,
        SpecterVariableInstancer,
        SpecterPairEventInstancer>, IGetEvent 
    { }
}
