using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityAtoms;
using UnityEngine;

namespace Liver {
    public class Spawner : SerializedMonoBehaviour {
        [Required] public AreaList AreaList;
        [Required] public GameObject Prefab;
        [Required] public Transform Container;
        [Required] public AreaDataValueList List;

        public void Start() {
            List.List = new List<AreaData>(AreaList.List);
            
            foreach (var item in List) {
                var go = Instantiate(Prefab, Container);
                var comp = go.GetComponent<Area>();
                comp.Initialize(item);
            }
        }
    }
}