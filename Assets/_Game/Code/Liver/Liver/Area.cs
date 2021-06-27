using System;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using Shapes;
using UnityEngine;
using UniRx;

namespace Liver {
    [RequireComponent(typeof(Rectangle))]
    public class Area : AbstractView<AreaData> {
        public ReactiveProperty<AreaData> State = new ReactiveProperty<AreaData>();
        private Rectangle _rect;
        private readonly List<Tween> _tweens = new List<Tween>();

        public override void Initialize(AreaData data) {
            var tr = transform;
            var pos = tr.localPosition;
            _rect = GetComponent<Rectangle>();
            _rect.Color = data.Color;
            _rect.Width = data.Width;
            _rect.Height = data.Height;
            pos.x = data.X;
            pos.y = data.Y;
            tr.localPosition = pos;
            
            State.Value = data;
            
            State.Value.SetRandomValues();
            State.SetValueAndForceNotify(State.Value);
        }

        public void Start() {
            State.Value.GameObject = gameObject;
            _rect = GetComponent<Rectangle>();
            State.Subscribe(_ => Display());
            WaitAndChange();
        }

        public void OnDestroy() {
            _tweens.ForEach(t => t.Kill());
            _tweens.Clear();
            State.Dispose();
        }

        private async void WaitAndChange() {
            while (true) {
                await UniTask.Delay(TimeSpan.FromSeconds(State.Value.IntervalTime));
                State.Value.SetRandomValues();
                State.SetValueAndForceNotify(State.Value);
            }
        }

        private void Display() {
            _tweens.ForEach(t => t.Kill());
            _tweens.Clear();
            var t = transform;
            var pos = t.localPosition;
            var state = State.Value;
            var time = state.IntervalTime;
            _tweens.Add(DOTween.To(() => _rect.Width, w => _rect.Width = w, state.Width, time));
            _tweens.Add(DOTween.To(() => _rect.Height, h => _rect.Height = h, state.Height, time));
            _tweens.Add(DOTween.To(() => _rect.Color, c => _rect.Color = c, state.Color, time));
            _tweens.Add(DOTween.To(() => pos.x, x => {
                var p = t.localPosition;
                p.x = x;
                t.localPosition = p;
            }, state.X, time));
            _tweens.Add(DOTween.To(() => pos.y, y => {
                var p = t.localPosition;
                p.y = y;
                t.localPosition = p;
            }, state.Y, time));
        }
    }
}