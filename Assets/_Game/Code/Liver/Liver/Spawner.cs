using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Linq;
using System.Reflection;
using Sirenix.OdinInspector;
using UnityAtoms;
using UnityEngine;

namespace Liver {
    public class Spawner : SerializedMonoBehaviour {
        [Required] public AreaList AreaList;
        [Required] public GameObject Prefab;
        [Required] public Transform Container;
        [Required] public Type StateType;
        [Required] public Type ViewType;

        [Required, NonSerialized, Sirenix.Serialization.OdinSerialize]
        public AreaDataValueList List;

        public void Start() {
            var listType = typeof(List<>).MakeGenericType(StateType);
            dynamic list = Activator.CreateInstance(listType, AreaList.List);
            List.List = list;


            foreach (var item in List) {
                var go = Instantiate(Prefab, Container);
                var type = typeof(AbstractView<>).MakeGenericType(StateType);
                dynamic comp = Convert.ChangeType(go.GetComponent(ViewType), type);
                comp.Initialize(item);
            }
        }
    }
}