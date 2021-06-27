using UnityEngine;
using System;
using Liver;

namespace UnityAtoms
{
    /// <summary>
    /// Variable of type `AreaData`. Inherits from `AtomVariable&lt;AreaData, AreaDataPair, AreaDataEvent, AreaDataPairEvent, AreaDataAreaDataFunction&gt;`.
    /// </summary>
    [EditorIcon("atom-icon-lush")]
    [CreateAssetMenu(menuName = "Unity Atoms/Variables/AreaData", fileName = "AreaDataVariable")]
    public sealed class AreaDataVariable : AtomVariable<AreaData, AreaDataPair, AreaDataEvent, AreaDataPairEvent, AreaDataAreaDataFunction>
    {
        protected override bool ValueEquals(AreaData other)
        {
            throw new NotImplementedException();
        }
    }
}
