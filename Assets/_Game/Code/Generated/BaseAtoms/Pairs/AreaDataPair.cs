using System;
using UnityEngine;
using Liver;
namespace UnityAtoms
{
    /// <summary>
    /// IPair of type `&lt;AreaData&gt;`. Inherits from `IPair&lt;AreaData&gt;`.
    /// </summary>
    [Serializable]
    public struct AreaDataPair : IPair<AreaData>
    {
        public AreaData Item1 { get => _item1; set => _item1 = value; }
        public AreaData Item2 { get => _item2; set => _item2 = value; }

        [SerializeField]
        private AreaData _item1;
        [SerializeField]
        private AreaData _item2;

        public void Deconstruct(out AreaData item1, out AreaData item2) { item1 = Item1; item2 = Item2; }
    }
}