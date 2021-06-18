using System;

namespace UnityAtoms
{
    /// <summary>
    /// Event Reference of type `Specter`. Inherits from `AtomEventReference&lt;Specter, SpecterVariable, SpecterEvent, SpecterVariableInstancer, SpecterEventInstancer&gt;`.
    /// </summary>
    [Serializable]
    public sealed class SpecterEventReference : AtomEventReference<
        Specter,
        SpecterVariable,
        SpecterEvent,
        SpecterVariableInstancer,
        SpecterEventInstancer>, IGetEvent 
    { }
}
