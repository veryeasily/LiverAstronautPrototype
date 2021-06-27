using UnityEngine;
using Sirenix.OdinInspector;
using UniRx;

namespace Liver {
    public abstract class AbstractView<T> : SerializedMonoBehaviour {
        public ReactiveProperty<T> Data;
        public virtual void Initialize(T data) {
            Data.SetValueAndForceNotify(data);
        }
    }
}