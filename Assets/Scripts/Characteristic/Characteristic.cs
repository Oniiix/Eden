using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Element Characteristic", menuName = "Characteristic/Element Characteristic")]
public class Characteristic : ScriptableObject
{
    [field:SerializeField] public CharacteristicData Age { get; set; } = new CharacteristicData() 
    {
        VarName = "age",
        CurrentValue = 0
    };
    [field: SerializeField] public float Distance { get; set; } = 20;
    //List d'habitat
    [field: SerializeField] public List<EHabitatType> Habitats { get; set; } = new();

    public virtual List<CharacteristicData> AllDatas()
    {
        return new List<CharacteristicData> { Age };
    }
}
