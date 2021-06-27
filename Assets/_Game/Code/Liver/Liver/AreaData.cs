using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Liver {
    [Serializable]
    public class AreaData {
        public Color Color = Color.green;
        public float X = 1f;
        public float Y = 1f;
        public float Width = 1f;
        public float Height = 1f;
        public float IntervalTime = 4f;
        [NonSerialized] public GameObject GameObject;

        public void SetRandomValues() {
            var topRight = GetTopRight();
            var botLeft = GetBottomLeft();
            var worldWidth = topRight.x - botLeft.x;
            var worldHeight = topRight.y - botLeft.y;
            var minX = botLeft.x;
            var maxX = topRight.x;
            var minY = botLeft.y;
            var maxY = topRight.y;
            X = Random.Range(minX, maxX);
            Y = Random.Range(minY, maxY);
            Width = Mathf.Min(Random.Range(1f, 5f), worldWidth - X);
            Height = Mathf.Min(Random.Range(1f, 5f), worldHeight - Y);
            var pow = Random.Range(1f, 3f);
            IntervalTime = 2f * pow * pow;
            Color = Random.ColorHSV();
            Color.a = Random.Range(0f, 1f);
        }

        private Vector3 GetTopRight() {
            return Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 10));
        }

        private Vector3 GetBottomLeft() {
            return Camera.main.ScreenToWorldPoint(new Vector3(0f, 0f, 10f));
        }
    }
}