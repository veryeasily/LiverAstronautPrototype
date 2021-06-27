using System;
using UnityAtoms.BaseAtoms;
using Liver;

namespace UnityAtoms
{
    /// <summary>
    /// Reference of type `AreaData`. Inherits from `AtomReference&lt;AreaData, AreaDataPair, AreaDataConstant, AreaDataVariable, AreaDataEvent, AreaDataPairEvent, AreaDataAreaDataFunction, AreaDataVariableInstancer, AtomCollection, AtomList&gt;`.
    /// </summary>
    [Serializable]
    public sealed class AreaDataReference : AtomReference<
        AreaData,
        AreaDataPair,
        AreaDataConstant,
        AreaDataVariable,
        AreaDataEvent,
        AreaDataPairEvent,
        AreaDataAreaDataFunction,
        AreaDataVariableInstancer>, IEquatable<AreaDataReference>
    {
        public AreaDataReference() : base() { }
        public AreaDataReference(AreaData value) : base(value) { }
        public bool Equals(AreaDataReference other) { return base.Equals(other); }
        protected override bool ValueEquals(AreaData other)
        {
            throw new NotImplementedException();
        }
    }
}
