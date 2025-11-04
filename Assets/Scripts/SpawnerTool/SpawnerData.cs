using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[Serializable]
public enum ESpawnerToolDensity
{
    Single,
    Multiple
}

[CreateAssetMenu(fileName ="SpawnerSettings")]
public class SpawnerData : ScriptableObject
{
    [field:SerializeField, Min(.1f)]
    public float SpawnerRadius { get; set; } = 1;

    [field:SerializeField]
    public ESpawnerToolDensity DensityType { get; set; } = ESpawnerToolDensity.Single;

    [field:SerializeField, Range(0, 10000)]
    public float Density { get; set; } = 10;

    [field:SerializeField]
    public bool UseSingleItem { get; set; } = true;

    [field:SerializeField]
    public Element Item { get; set; } = null;

    [field:SerializeField]
    public List<Element> Items { get; set; } = new();
}
