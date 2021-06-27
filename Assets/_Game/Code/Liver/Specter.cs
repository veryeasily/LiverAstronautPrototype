using System;
using System.Reflection;
using UnityEngine;

[CreateAssetMenu(fileName = "NewSpirit", menuName = "Liver/Specter")]
public class Specter : ScriptableObject, IEquatable<Specter> {
    public Color Color;
    public Sprite Sprite;
    public string SpiritName;
    public float TimeEquipped;
    public AudioClip AddToInventorySound;

    public bool Equals(Specter other) {
        Activator.CreateInstance(typeof(Liver.Area));
        return this == other;
    }
}