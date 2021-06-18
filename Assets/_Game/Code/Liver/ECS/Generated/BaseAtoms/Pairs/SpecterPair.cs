using System;
using UnityEngine;
namespace UnityAtoms
{
    /// <summary>
    /// IPair of type `&lt;Specter&gt;`. Inherits from `IPair&lt;Specter&gt;`.
    /// </summary>
    [Serializable]
    public struct SpecterPair : IPair<Specter>
    {
        public Specter Item1 { get => _item1; set => _item1 = value; }
        public Specter Item2 { get => _item2; set => _item2 = value; }

        [SerializeField]
        private Specter _item1;
        [SerializeField]
        private Specter _item2;

        public void Deconstruct(out Specter item1, out Specter item2) { item1 = Item1; item2 = Item2; }
    }
}