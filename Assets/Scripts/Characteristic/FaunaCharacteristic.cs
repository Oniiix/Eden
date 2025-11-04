using System.Collections.Generic;
using UnityEngine;

public enum TDietTypeEnum
{
    Carnivorous,
    Herbivorous
}

[CreateAssetMenu(fileName ="Fauna Characteristic", menuName = "Characteristic/Fauna Characteristic")]
public class FaunaCharacteristic : LivingElementCharacteristic
{

    [SerializeField] public CharacteristicData life = new CharacteristicData()
    {
        VarName = "life"
    };
    [SerializeField] public CharacteristicData hunger = new CharacteristicData()
    {
        VarName = "hunger"
    };
    [field:SerializeField] public int HungerLimit { get; set; } = 20;
    [field:SerializeField] public TDietTypeEnum DietType { get; set; }

    public override List<CharacteristicData> AllDatas()
    {
        List<CharacteristicData> _allDatas = base.AllDatas();
        _allDatas.Add(life);
        _allDatas.Add(hunger);
        return _allDatas;
    }
}
