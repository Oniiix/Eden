using System;
using UnityEngine;

[Serializable]
public class CharacteristicData 
{
   [field: SerializeField] public string VarName { get;  set; }
    [field: SerializeField]public int CurrentValue { get;  set; } = 50;
   [field: SerializeField] public int MaxValue { get;  set; } = 100;
   [field: SerializeField] public int MinValue { get;  set; } = 0;
}
