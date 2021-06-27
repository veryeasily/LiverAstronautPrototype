using Sirenix.OdinInspector;
using System.Collections.Generic;
using UnityEngine;

namespace Liver {
    [CreateAssetMenu(fileName = "NewAreaList", menuName = "Liver/AreaList")]
    public class AreaList : SerializedScriptableObject {
        public List<AreaData> List = new List<AreaData>();
    }
}