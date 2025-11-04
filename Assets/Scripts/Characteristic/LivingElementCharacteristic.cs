using System.Collections.Generic;
using UnityEngine;

public enum TTypeEnum
{
    Meat,
    Plant
}

public abstract class LivingElementCharacteristic : Characteristic
{
    [field:SerializeField] public TTypeEnum ElementType { get; set; } 

    [SerializeField] public CharacteristicData thirst = new CharacteristicData()
    {
        VarName = "thirst"
    };
    [field:SerializeField] public int ThirstLimit { get; set; } = 20;


    public override List<CharacteristicData> AllDatas()
    {
        List<CharacteristicData> _allDatas = base.AllDatas();
        _allDatas.Add(thirst);
        return _allDatas;
    }
}
