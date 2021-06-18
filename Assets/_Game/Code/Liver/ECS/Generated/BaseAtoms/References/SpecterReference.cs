using System;
using UnityAtoms.BaseAtoms;

namespace UnityAtoms
{
    /// <summary>
    /// Reference of type `Specter`. Inherits from `EquatableAtomReference&lt;Specter, SpecterPair, SpecterConstant, SpecterVariable, SpecterEvent, SpecterPairEvent, SpecterSpecterFunction, SpecterVariableInstancer, AtomCollection, AtomList&gt;`.
    /// </summary>
    [Serializable]
    public sealed class SpecterReference : EquatableAtomReference<
        Specter,
        SpecterPair,
        SpecterConstant,
        SpecterVariable,
        SpecterEvent,
        SpecterPairEvent,
        SpecterSpecterFunction,
        SpecterVariableInstancer>, IEquatable<SpecterReference>
    {
        public SpecterReference() : base() { }
        public SpecterReference(Specter value) : base(value) { }
        public bool Equals(SpecterReference other) { return base.Equals(other); }
    }
}
