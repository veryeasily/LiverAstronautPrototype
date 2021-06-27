using System;
using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;
using Sirenix.OdinInspector;
using UnityAtoms;
using UnityEngine;

namespace Liver {
    public class Spawner : SerializedMonoBehaviour {
        [Required, ValueDropdown("GetViewTypes")]
        public Type ViewType;

        [Required, ValueDropdown("GetStateTypes")]
        public Type StateType;

        [Required] public AreaList AreaList;
        [Required] public GameObject Prefab;
        [Required] public Transform Container;
        [Required] public AreaDataValueList List;

        private static readonly Type _baseView = typeof(AbstractView<>);

        public void Start() {
            var listType = typeof(List<>).MakeGenericType(StateType);
            dynamic list = Activator.CreateInstance(listType, AreaList.List);
            List.List = list;


            foreach (var item in List) {
                var go = Instantiate(Prefab, Container);
                // var type = typeof(AbstractView<>).MakeGenericType(StateType);
                // dynamic comp = Convert.ChangeType(go.GetComponent(ViewType), type);
                dynamic comp = go.GetComponent(ViewType);
                comp.Initialize(item);
            }
        }

        [UsedImplicitly]
        public IEnumerable<Type> GetStateTypes() {
            return TypesForDropdown(typeof(object));
        }

        [UsedImplicitly]
        public IEnumerable<Type> GetViewTypes() {
            return TypesForDropdown(_baseView);
        }

        private IEnumerable<Type> TypesForDropdown(Type type) {
            return typeof(Spawner).Assembly.GetTypes()
                .Where(x => !x.IsAbstract)
                .Where(x => !x.IsGenericTypeDefinition)
                .Where(type.IsAssignableFrom);
        }
    }
}