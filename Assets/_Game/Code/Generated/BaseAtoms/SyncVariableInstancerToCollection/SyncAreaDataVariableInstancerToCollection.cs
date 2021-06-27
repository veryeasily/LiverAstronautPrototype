using UnityEngine;
using UnityAtoms.BaseAtoms;
using Liver;

namespace UnityAtoms
{
    /// <summary>
    /// Adds Variable Instancer's Variable of type AreaData to a Collection or List on OnEnable and removes it on OnDestroy. 
    /// </summary>
    [AddComponentMenu("Unity Atoms/Sync Variable Instancer to Collection/Sync AreaData Variable Instancer to Collection")]
    [EditorIcon("atom-icon-delicate")]
    public class SyncAreaDataVariableInstancerToCollection : SyncVariableInstancerToCollection<AreaData, AreaDataVariable, AreaDataVariableInstancer> { }
}
